using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StudentManagementAPI.Exceptions;
using TrainingCenter.BLL.DTOS.Student;
using TrainingCenter.BLL.DTOS.Track;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.BLL.Specifications.StudentSpecifications;
using TrainingCenter.BLL.Specifications.TrackSpecification;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.Implementations;
using TrainingCenter.DAL.Repositories.Interfaces;

namespace TrainingCenter.BLL.Services.Implementation
{
    public class TrackService(IUnitOfWork unitOfWork,IMapper mapper) : ITrackService
    {

        public async Task<IEnumerable<TrackDTO>> GetAll(string? trackName, TrackLevel? trackLevel, TrainingStatus? trackStatus, int? instructorId)
        {
            var TrackSpecification = new TrackByKeywordandlevelandstatusandInstructorId(trackName,trackLevel,trackStatus, instructorId);
            var GetAllTracks = await unitOfWork.Repository<TrainingTrack>().GetAll(TrackSpecification);
            var TracksDTO = mapper.Map<IEnumerable<TrainingTrack>, IEnumerable<TrackDTO>>(GetAllTracks);
            return TracksDTO;
        }


        public async Task<TrackDetailsDTO> GetById(int id)
        {
            var TrackSpecification = new TrackByIdSpecification(id);
            var GetTrackInstructor = await unitOfWork.Repository<TrainingTrack>().GetById(TrackSpecification);
            if (GetTrackInstructor is null)
                throw new BusinessException("Track is not found", 404);
            var TrackDetailsDTO = mapper.Map<TrainingTrack, TrackDetailsDTO>(GetTrackInstructor);
            return TrackDetailsDTO;
        }

        public async Task Create(CreateTrackDTO trackdto)
        {
            if(trackdto.Capacity<1 || trackdto.Capacity>30)
                throw new BusinessException("Track capacity must in range between 1 to 30", 400);

            if (trackdto.StartDate >= trackdto.EndDate) 
                throw new BusinessException("Track StartDate must be less than EndDate", 400);
            

            var track = mapper.Map<TrainingTrack>(trackdto);

            await unitOfWork.Repository<TrainingTrack>().Create(track);

            await unitOfWork.CompleteChanges();
        }


        public async Task Update(UpdateTrackDTO trackdto)
        {
            if (trackdto.Capacity < 1 || trackdto.Capacity > 30)
                throw new BusinessException("Track capacity must in range between 1 to 30", 400);

            if (trackdto.StartDate >= trackdto.EndDate)
                throw new BusinessException("Track StartDate must be less than EndDate", 400);

            var specId = new TrackByIdSpecification(trackdto.Id);

            var existingTrack = await unitOfWork.Repository<TrainingTrack>().GetById(specId);

            if (existingTrack is null)
                throw new BusinessException("Track not found", 404);

            var specInsid = new TrackByInstructorIdSpecification(trackdto.InstructorId);

            var existingInstructor = await unitOfWork.Repository<TrainingTrack>().GetById(specInsid);

            if (existingInstructor is null)
                throw new BusinessException("Instructor not found", 404);

            var track = mapper.Map<TrainingTrack>(trackdto);

            await unitOfWork.Repository<TrainingTrack>().Update(track);

            await unitOfWork.CompleteChanges();

           
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
