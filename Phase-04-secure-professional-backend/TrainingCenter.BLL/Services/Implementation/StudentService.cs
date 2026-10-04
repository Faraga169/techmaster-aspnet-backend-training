using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using StudentManagementAPI.Exceptions;
using TrainingCenter.BLL.Common;
using TrainingCenter.BLL.DTOS.Student;
using TrainingCenter.BLL.DTOS.User;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.BLL.Specifications.StudentSpecifications;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.Interfaces;

namespace TrainingCenter.BLL.Services.Implementation
{
    public class StudentService(IUnitOfWork unitOfWork,IMapper mapper,IHttpContextAccessor contextAccessor,UserManager<ApplicationUser> userManager,IActivityLogService activityLogService) : IStudentService
    {

        public async Task<PaginatedResult<StudentDTO>> GetAll(string? searchbyName, bool? IsActive, int pagenumber = 1, int pagesize = 5)
        {
            if (pagenumber < 1)
                throw new BusinessException("Page number must be greater than 0", 400);

            if (pagesize < 1)
                throw new BusinessException("Page size must be greater than 0", 400);

            var StudentSpecification = new StudentBySearchNameorIsActiveSpecification(searchbyName, IsActive,pagenumber,pagesize);
            var totalCount = await unitOfWork.Repository<Student>().Count(StudentSpecification);
            var GetAllStudent = await unitOfWork.Repository<Student>().GetAll(StudentSpecification);
            var StudentsDTO = mapper.Map<IEnumerable<Student>,IEnumerable<StudentDTO>>(GetAllStudent);
            return new PaginatedResult<StudentDTO>
            {
                Items = StudentsDTO,
                PageNumber = pagenumber,
                PageSize = pagesize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(
            totalCount / (double)pagesize)
            };
        }

        public async Task<StudentEnrollmentDTO> GetById(int id)
        {
           
            var StudentSpecification = new StudentByIdSpecification(id);
            var GetStudentEnrollment = await unitOfWork.Repository<Student>().GetById(StudentSpecification);
            if (GetStudentEnrollment is null)
                throw new BusinessException("Student is not found", 404);


            var StudentEnrollmentDTO = mapper.Map<Student,StudentEnrollmentDTO>(GetStudentEnrollment);
            return StudentEnrollmentDTO;

        }
        public async Task<StudentDTO> Create(CreateStudentDTO dto)
        {
            

            var spec = new StudentByEmailSpecification(dto.Email);

            var existingStudent = await unitOfWork.Repository<Student>().GetById(spec);

            if (existingStudent is not null)
                throw new BusinessException("Email already exists",400);

            await unitOfWork.BeginTransactionAsync();

            try
            {

                var user = new ApplicationUser()
                {

                    Email = dto.Email,
                    UserName = dto.FullName,
                    
                };



                var createUser = await userManager.CreateAsync(user, dto.Password);
                if (!createUser.Succeeded)
                {

                    var errors = string.Join(", ", createUser.Errors.Select(e => e.Description));
                    throw new BusinessException($"{errors}", 400);
                }

                var addToRole = await userManager.AddToRoleAsync(user, "Student");

                if (!addToRole.Succeeded)
                {
                    var errors = string.Join(", ", addToRole.Errors.Select(e => e.Description));

                    throw new BusinessException(errors, 400);
                }

                var student = mapper.Map<Student>(dto);

                student.UserId = user.Id;

                await unitOfWork.Repository<Student>().Create(student);
                await unitOfWork.CompleteChanges();
                await activityLogService.LogAsync(new ActivityLog()
                {
                    Action = "StudentCreate",
                    EntityName = "Student",
                    EntityId = student.Id.ToString(),
                    Description =
                                 $"Student {student.FullName} Created Successfully"

                });

                await unitOfWork.CompleteChanges();

                await unitOfWork.CommitTransactionAsync();

                return mapper.Map<StudentDTO>(student);
            }
            catch
            {
                await unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }


        public async Task<StudentDTO> GetMyProfile()
        {
            var userId = contextAccessor.HttpContext?.User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId is null)
                throw new BusinessException("User claims not found.", 401);

            var spec = new StudentByUserIdSpecification(userId);

            var student = await unitOfWork
                .Repository<Student>()
                .GetById(spec);

            if (student is null)
                throw new BusinessException("Student profile not found.", 404);

            return mapper.Map<StudentDTO>(student);
        }
        public async Task<StudentDTO> Update(int id,UpdateStudentDTO dto)
        {
            
            var spec = new StudentByIdSpecification(id);

            var existingStudent = await unitOfWork.Repository<Student>().GetById(spec);

            if(existingStudent is null)
                throw new BusinessException("Student not found", 404);

            if (existingStudent is  null)
                throw new BusinessException("Student not found", 404);

            var student = mapper.Map<Student>(dto);

            await unitOfWork.Repository<Student>().Update(student);

            await unitOfWork.CompleteChanges();
            return mapper.Map<StudentDTO>(student);
        }


        public async Task<StudentDTO> UpdateMyProfile(UpdateStudentDTO dto)
        {
            var userId = contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId is null)
                throw new BusinessException("User Claims not found", 401);

            var user = await userManager.FindByIdAsync(userId);

            if (user is null)
                throw new BusinessException("User not found", 404);

            

            var spec = new StudentByUserIdSpecification(userId);

            var existingStudent = await unitOfWork.Repository<Student>().GetById(spec);

            if (existingStudent is null)
                throw new BusinessException("Student not found", 404);



           mapper.Map(dto, existingStudent);

            user.UpdateAt = DateTime.UtcNow;
            user.Email = existingStudent.Email;
            user.PhoneNumber = existingStudent.PhoneNumber;
            user.UserName = existingStudent.FullName;

           

            await unitOfWork.Repository<Student>().Update(existingStudent);

            await unitOfWork.CompleteChanges();

            return mapper.Map<StudentDTO>(existingStudent);
        }

        public async Task<bool> Delete(int id)
        {
            var spec = new StudentByIdSpecification(id);

            var existingStudent = await unitOfWork.Repository<Student>().GetById(spec);

            if (existingStudent is null)
                throw new BusinessException("Student not found", 404);        

            existingStudent.IsActive= false;
            await unitOfWork.Repository<Student>().Delete(id);
            await unitOfWork.CompleteChanges();
            return true;
        }

        

      

       
    }
}
