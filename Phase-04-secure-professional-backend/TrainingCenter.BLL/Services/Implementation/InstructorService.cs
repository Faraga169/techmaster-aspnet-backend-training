using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using StudentManagementAPI.Exceptions;
using TrainingCenter.BLL.DTOS.Instructor;
using TrainingCenter.BLL.DTOS.Student;
using TrainingCenter.BLL.DTOS.Track;
using TrainingCenter.BLL.DTOS.User;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.BLL.Specifications.InstructorSpecification;
using TrainingCenter.BLL.Specifications.TrackSpecification;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.Interfaces;

namespace TrainingCenter.BLL.Services.Implementation
{
    public class InstructorService(IUnitOfWork unitOfWork, IMapper mapper,IHttpContextAccessor contextAccessor,UserManager<ApplicationUser> userManager) : IInstrcutorService
    {

        public async Task<IEnumerable<InstructorDTO>> GetAll()
        {
            var instructors =await unitOfWork.Repository<Instructor>().GetAll(null!);

            return mapper.Map<IEnumerable<InstructorDTO>>(instructors);
        }



        public async Task AssignInstructor(int trackId, int instructorId)
        {
            var track = await unitOfWork.Repository<TrainingTrack>().GetById(new TrackByIdSpecification(trackId));

            if (track is null)
                throw new BusinessException("Track not found.", 404);

            var instructor = await unitOfWork.Repository<Instructor>().GetById(new InstructorbyIdspecification(instructorId));

            if (instructor is null)
                throw new BusinessException("Instructor not found.", 404);

            if (!instructor.IsActive)
                throw new BusinessException("Cannot assign an inactive instructor.",400);

            track.InstructorId = instructorId;

            await unitOfWork.CompleteChanges();
        }
        public async Task<InstructorDetailsDTO> GetById(int id)
        {
            var userId = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = contextAccessor.HttpContext.User.IsInRole("Admin");
            if (userId is null)
                throw new BusinessException("User Claims not found", 401);

            var spec = new InstructorbyIdspecification(id);

            var instructor =await unitOfWork.Repository<Instructor>().GetById(spec);

            if (instructor is null)
                throw new BusinessException("Instructor not found", 404);

            if (!isAdmin && instructor.UserId != userId)
                throw new BusinessException("You are not allowed to see this profile", 403);

            return mapper.Map<InstructorDetailsDTO>(instructor);
        }

        public async Task<InstructorDTO> Create(CreateInstructorDTO dto)
        {
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

                var addToRole = await userManager.AddToRoleAsync(user, "Instructor");

                if (!addToRole.Succeeded)
                {
                    var errors = string.Join(", ", addToRole.Errors.Select(e => e.Description));

                    throw new BusinessException(errors, 400);
                }

                var instructor = mapper.Map<Instructor>(dto);

                instructor.UserId = user.Id;

                await unitOfWork.Repository<Instructor>().Create(instructor);

                await unitOfWork.CompleteChanges();

                await unitOfWork.CommitTransactionAsync();

                return mapper.Map<InstructorDTO>(instructor);
            }
            catch
            {
                await unitOfWork.RollbackTransactionAsync();
                throw;
            }
          
        }

        public async Task<InstructorDTO> Update(UpdateInstructorDTO dto)
        {
            var spec = new InstructorbyIdspecification(dto.Id);

            var existingInstructor =await unitOfWork.Repository<Instructor>().GetById(spec);

            if (existingInstructor is null)
                throw new BusinessException("Instructor not found", 404);

            var instructor=mapper.Map<Instructor>(dto);

            await unitOfWork.Repository<Instructor>() .Update(instructor);

            await unitOfWork.CompleteChanges();

            return mapper.Map<InstructorDTO>(instructor);
        }

        public async Task<IEnumerable<TrackDTO>> GetTracksByInstructorId(int id)
        {
           
            var spec=new InstructorbyIdspecification(id);
            var instructor =await unitOfWork.Repository<Instructor>().GetById(spec);

            if (instructor is null)
                throw new BusinessException("Instructor not found", 404);
            var specins = new TrackByInstructorIdSpecification(id);
            var tracks =await unitOfWork.InstructorRepository().GetTracksByInstructorId(specins);

            return mapper.Map<IEnumerable<TrackDTO>>(tracks);
        }



    }
}
