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
using TrainingCenter.BLL.Specifications.InstructorSpecification;
using TrainingCenter.BLL.Specifications.StudentSpecifications;
using TrainingCenter.BLL.Specifications.TrackSpecification;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.Implementations;
using TrainingCenter.DAL.Repositories.Interfaces;

namespace TrainingCenter.BLL.Services.Implementation
{
    public class TrackService(IUnitOfWork unitOfWork,IMapper mapper,IHttpContextAccessor contextAccessor,UserManager<ApplicationUser> userManager) : ITrackService
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
            

            var track = mapper.Map<TrainingTrack>(trackdto);

            await unitOfWork.Repository<TrainingTrack>().Create(track);

            await unitOfWork.CompleteChanges();
            return mapper.Map<TrackDTO>(track);
        }


        public async Task<TrackDTO> Update(UpdateTrackDTO trackdto)
        {
            var userId = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var isAdmin = contextAccessor.HttpContext.User.IsInRole("Admin");

            if (userId is null)
                throw new BusinessException("User Claims not found", 401);

            if (trackdto.Capacity < 1 || trackdto.Capacity > 30)
                throw new BusinessException("Track capacity must be in range between 1 and 30", 400);

            if (trackdto.StartDate >= trackdto.EndDate)
                throw new BusinessException("Track StartDate must be less than EndDate", 400);

            // 1. Get the actual track
            var specId = new TrackByIdSpecification(trackdto.Id);

            var existingTrack =await unitOfWork.Repository<TrainingTrack>().GetById(specId);

            if (existingTrack is null)
                throw new BusinessException("Track not found", 404);

            // 2. Check ownership of the EXISTING track
            if (!isAdmin && existingTrack.Instructor?.UserId != userId)
                throw new BusinessException("You are not allowed to update this track.", 403);

            // 3. Check the NEW instructor
            var instructorSpec =new InstructorbyIdspecification(trackdto.InstructorId!.Value);

            var existingInstructor =
                await unitOfWork.Repository<Instructor>().GetById(instructorSpec);

            if (existingInstructor is null)
                throw new BusinessException("Instructor not found", 404);

            // 4. Instructor cannot transfer the track to another instructor
            if (!isAdmin &&(trackdto.InstructorId != existingTrack.InstructorId||trackdto.Code!=existingTrack.Code||trackdto.Price!=existingTrack.Price||trackdto.Status!=existingTrack.Status))
                throw new BusinessException("You are not allowed to change the instructor or price or code or status of this track.",403);

            // 5. Update the existing entity
            mapper.Map(trackdto, existingTrack);

            await unitOfWork.Repository<TrainingTrack>().Update(existingTrack);

            await unitOfWork.CompleteChanges();

            return mapper.Map<TrackDTO>(existingTrack);
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
