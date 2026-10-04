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
using TrainingCenter.BLL.DTOS.Payment;
using TrainingCenter.BLL.DTOS.Student;
using TrainingCenter.BLL.DTOS.Track;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.BLL.Specifications.EnrollmentSpecification;
using TrainingCenter.BLL.Specifications.InstructorSpecification;
using TrainingCenter.BLL.Specifications.StudentSpecifications;
using TrainingCenter.BLL.Specifications.TrackSpecification;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.Implementations;
using TrainingCenter.DAL.Repositories.Interfaces;

namespace TrainingCenter.BLL.Services.Implementation
{
    public class TrackService(IUnitOfWork unitOfWork,IMapper mapper,IHttpContextAccessor contextAccessor,UserManager<ApplicationUser> userManager,IActivityLogService activityLogService) : ITrackService
    {

        public async Task<IEnumerable<TrackDTO>> GetAll(string? trackName, TrackLevel? trackLevel, TrainingStatus? trackStatus, int? instructorId)
        {
            if (trackLevel.HasValue && !Enum.IsDefined(typeof(TrackLevel), trackLevel.Value))
                throw new BusinessException("Invalid track level.", 400);
            var TrackSpecification = new TrackByKeywordandlevelandstatusandInstructorId(trackName,trackLevel,trackStatus, instructorId);
            var GetAllTracks = await unitOfWork.Repository<TrainingTrack>().GetAll(TrackSpecification);
            var TracksDTO = mapper.Map<IEnumerable<TrainingTrack>, IEnumerable<TrackDTO>>(GetAllTracks);
            return TracksDTO;
        }

        public async Task<IEnumerable<TrackDTO>> GetAvailableTracks()
        {
            var specification = new AvailableTracksSpecification();

            var tracks = await unitOfWork.Repository<TrainingTrack>().GetAll(specification);

            return mapper.Map<IEnumerable<TrackDTO>>(tracks);
        }

        public async Task<TrackDetailsDTO> GetById(int id)
        {
            var userId = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = contextAccessor.HttpContext.User.IsInRole("Admin");
            if (userId is null)
                throw new BusinessException("User Claims not found", 401);
           
            
            var TrackSpecification = new TrackByIdSpecification(id);

            var GetTrackInstructor = await unitOfWork.Repository<TrainingTrack>().GetById(TrackSpecification);
            if (GetTrackInstructor is null)
                throw new BusinessException("Track is not found", 404);

            if(!isAdmin && GetTrackInstructor?.Instructor?.UserId!=userId )
                throw new BusinessException("You are not allowed to access this track.", 403);


            var TrackDetailsDTO = mapper.Map<TrainingTrack, TrackDetailsDTO>(GetTrackInstructor);
            return TrackDetailsDTO;
        }

        public async Task<TrackDTO> Create(CreateTrackDTO trackdto)
        {




            var spec = new TrackBYCodeSpecification(trackdto.Code);
            var Codeexist = await unitOfWork.Repository<TrainingTrack>().GetById(spec);

            if(Codeexist is not null)
                throw new BusinessException("TrackCode must be unique", 409);

            var instructor = await unitOfWork.Repository<Instructor>().GetById(new InstructorbyIdspecification(trackdto.InstructorId!.Value));

            if (instructor is null)
                throw new BusinessException("Instructor not found.", 404);

            if (trackdto.Capacity<1 || trackdto.Capacity>30)
                throw new BusinessException("Track capacity must in range between 1 to 30", 400);

            if (trackdto.StartDate >= trackdto.EndDate) 
                throw new BusinessException("Track StartDate must be less than EndDate", 400);


            await unitOfWork.BeginTransactionAsync();

            try
            {
                var track = mapper.Map<TrainingTrack>(trackdto);

                await unitOfWork.Repository<TrainingTrack>().Create(track);

               
                await unitOfWork.CompleteChanges();

                await activityLogService.LogAsync(
                    new ActivityLog
                    {
                        Action = "TrackCreated",
                        EntityName = "Track",
                        EntityId = track.Id.ToString(),
                        Description = $"Track '{track.Title}' was created"
                    });

                await unitOfWork.CompleteChanges();

                await unitOfWork.CommitTransactionAsync();

                return mapper.Map<TrackDTO>(track);
            }
            catch
            {
                await unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task AssignInstructor(int trackId, int instructorId)
        {
            var track = await unitOfWork.Repository<TrainingTrack>().GetById(new TrackByIdForAssignmentSpecification(trackId));

            if (track is null)
                throw new BusinessException("Track not found.", 404);

            var instructor = await unitOfWork.Repository<Instructor>().GetById(new InstructorbyIdspecification(instructorId));

            if (instructor is null)
                throw new BusinessException("Instructor not found.", 404);

            if (!instructor.IsActive)
                throw new BusinessException("Cannot assign an inactive instructor.", 400);

            track.InstructorId = instructorId;

         

            await unitOfWork.Repository<TrainingTrack>().Update(track);

          

            await unitOfWork.CompleteChanges();

      

        }
        public async Task<TrackDTO> Update(int id, UpdateTrackDTO trackdto)
        {
            var httpContext = contextAccessor.HttpContext; var userId = httpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier); 
            var isAdmin = httpContext?.User.IsInRole("Admin") ?? false; 
            if (userId is null) 
                throw new BusinessException("User Claims not found", 401); 
            // Basic validation
             if (trackdto.Capacity < 1 || trackdto.Capacity > 30)
             throw new BusinessException( "Track capacity must be in range between 1 and 30", 400); 
            if (trackdto.StartDate >= trackdto.EndDate) 
                throw new BusinessException( "Track StartDate must be less than EndDate", 400); 
            // Get existing track
            var trackSpec = new TrackByIdSpecification(id); 
                var existingTrack = await unitOfWork.Repository<TrainingTrack>().GetById(trackSpec);

            if (existingTrack is null) 
                throw new BusinessException("Track not found", 404);
         


           
            // Ownership
            if (!isAdmin && existingTrack.Instructor?.UserId != userId) 
             throw new BusinessException( "You are not allowed to update this track.", 403); 
            
            
           
           
            if (!isAdmin) 
            { 
                if (trackdto.InstructorId != existingTrack.InstructorId) 
                { 
                    throw new BusinessException( "You are not allowed to change the instructor of this track.", 403); 
                
                } 
                if (trackdto.Code != existingTrack.Code) 
                { 
                    throw new BusinessException( "You are not allowed to change the track code.", 403); 
                } 
                if (trackdto.Price != existingTrack.Price) 
                { 
                    throw new BusinessException( "You are not allowed to change the track price.", 403); 
                } 
                if (trackdto.Status != existingTrack.Status) 
                { 
                    throw new BusinessException( "You are not allowed to change the track status.", 403); 
                } 
            
            } 
           
            var instructorSpec = new InstructorbyIdspecification(trackdto.InstructorId);
            var existingInstructor = await unitOfWork.Repository<Instructor>().GetById(instructorSpec);


            if (existingInstructor is null) 
                throw new BusinessException( "Instructor not found", 404); 
            if (!existingInstructor.IsActive) 
                throw new BusinessException( "Cannot assign an inactive instructor.", 400); 
            var enrolledStudentsSpec = new StudentsBYtrackIdSpecification(id); 
            var enrolledStudents = await unitOfWork.EnrollmentRepository().GetStudentsByTrackId(enrolledStudentsSpec); 
            var enrolledCount = enrolledStudents.Count(); 
            if (trackdto.Capacity < enrolledCount) 
             throw new BusinessException( $"Track capacity cannot be less than the current number of enrolled students ({enrolledCount}).", 400);
            var trackwithincludeSpec = new TrackByIdForAssignmentSpecification(id);
            var existingTrackwithoutinclude = await unitOfWork.Repository<TrainingTrack>().GetById(trackwithincludeSpec);
            mapper.Map(trackdto, existingTrackwithoutinclude);
        

            await unitOfWork.Repository<TrainingTrack>().Update(existingTrackwithoutinclude); 
            await unitOfWork.CompleteChanges(); 
            return mapper.Map<TrackDTO>(existingTrackwithoutinclude); 
        
        }

        public async Task<bool> Delete(int id)
        {
            var spec = new TrackByIdSpecification(id);

            var existingTrack = await unitOfWork.Repository<TrainingTrack>().GetById(spec);

            if (existingTrack is null)
                throw new BusinessException("Track not found", 404);

            var Activespec = new TrackexistActiveEnrollments(id);
            var TrackexistingActiveEnrollment = await unitOfWork.Repository<TrainingTrack>().GetById(Activespec);

            if(TrackexistingActiveEnrollment is not null)
                throw new BusinessException("Track cannot deleted Because has Active enrollment", 400);

            await unitOfWork.Repository<TrainingTrack>().Delete(id);
            await unitOfWork.CompleteChanges();
            return true;
        }

        
    }
}
