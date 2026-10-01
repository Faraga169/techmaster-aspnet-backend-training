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
using TrainingCenter.BLL.DTOS;
using TrainingCenter.BLL.DTOS.Student;
using TrainingCenter.BLL.DTOS.User;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.BLL.Specifications.StudentSpecifications;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.Interfaces;

namespace TrainingCenter.BLL.Services.Implementation
{
    public class StudentService(IUnitOfWork unitOfWork,IMapper mapper,IHttpContextAccessor contextAccessor,UserManager<ApplicationUser> userManager) : IStudentService
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
            var userId = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = contextAccessor.HttpContext.User.IsInRole("Admin");
            if (userId is null)
                throw new BusinessException("User Claims not found", 401);

            var StudentSpecification = new StudentByIdSpecification(id);
            var GetStudentEnrollment = await unitOfWork.Repository<Student>().GetById(StudentSpecification);
            if (GetStudentEnrollment is null)
                throw new BusinessException("Student is not found", 404);

            if(!isAdmin&&GetStudentEnrollment.UserId!=userId)
                throw new BusinessException("You are not allowed to see this profile", 403);

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

                await unitOfWork.CommitTransactionAsync();

                return mapper.Map<StudentDTO>(student);
            }
            catch
            {
                await unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }


        public async Task<StudentDTO> Update(UpdateStudentDTO dto)
        {
            
            var isAdmin = contextAccessor.HttpContext.User.IsInRole("Admin");
            

            var spec = new StudentByIdSpecification(dto.Id);

            var existingStudent = await unitOfWork.Repository<Student>().GetById(spec);

            if (!isAdmin && dto.IsActive != existingStudent.IsActive)
                throw new BusinessException("You are not allowed to change in IsActice Field", 403);

            if (existingStudent is  null)
                throw new BusinessException("Student not found", 404);

            var student = mapper.Map<Student>(dto);

            await unitOfWork.Repository<Student>().Update(student);

            await unitOfWork.CompleteChanges();
            return mapper.Map<StudentDTO>(student);
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
