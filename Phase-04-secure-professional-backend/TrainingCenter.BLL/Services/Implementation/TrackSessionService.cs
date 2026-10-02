using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using StudentManagementAPI.Exceptions;
using TrainingCenter.BLL.DTOS.Session;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.BLL.Specifications.EnrollmentSpecification;
using TrainingCenter.BLL.Specifications.InstructorSpecification;
using TrainingCenter.BLL.Specifications.SessionSpecification;
using TrainingCenter.BLL.Specifications.StudentSpecifications;
using TrainingCenter.BLL.Specifications.TrackSpecification;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.Interfaces;
using static System.Collections.Specialized.BitVector32;

namespace TrainingCenter.BLL.Services.Implementation
{
    public class TrackSessionService(IUnitOfWork unitOfWork,IMapper mapper,IHttpContextAccessor contextAccessor) : ITrackSession
    {
        public async Task<IEnumerable<TrackSessionDTO>> GetAll()
        {
            var userId=contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
                throw new BusinessException("User has not claims", 401);

            var Instructorspec = new InstructorByUserIdSpecification(userId);
            var Instructor = await unitOfWork.Repository<Instructor>().GetById(Instructorspec);

            if(Instructor is null)
                throw new BusinessException("Instructor not found", 404);


            var sessionsspec = new GetSessionsbyInstructorIdSpecification(Instructor.Id);
            var sessions = await unitOfWork.Repository<TrackSession>().GetAll(sessionsspec);

            if(!sessions.Any())
                return Enumerable.Empty<TrackSessionDTO>();

            var sessionsDto=mapper.Map<IEnumerable<TrackSession>, IEnumerable<TrackSessionDTO>>(sessions);

            return sessionsDto;


        }


        public async Task<TrackSessionDTO> Create(int trackId, CreateSessionDTO createSessionDTO)
        {
            var userId = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
                throw new BusinessException("User has not claims", 401);

            var Instructorspec = new InstructorByUserIdSpecification(userId);
            var Instructor = await unitOfWork.Repository<Instructor>().GetById(Instructorspec);

            if (Instructor is null)
                throw new BusinessException("Instructor not found", 404);

            var trackspec=new TrackByIdSpecification(trackId);
            var Track = await unitOfWork.Repository<TrainingTrack>().GetById(trackspec);

            if(Track is null)
                throw new BusinessException("Track not found", 404);

            if(Instructor.Id!=Track.InstructorId)
                throw new BusinessException("You are not assigned to this track.",403);

            var tracksession=mapper.Map<CreateSessionDTO, TrackSession>(createSessionDTO);
            tracksession.TrackId = trackId;
            tracksession.CreatedByInstructorId = Instructor.Id;
            tracksession.IsCompleted = false;

            await unitOfWork.Repository<TrackSession>().Create(tracksession);
            await unitOfWork.CompleteChanges();

            return mapper.Map<TrackSessionDTO>(tracksession);
        }

        


        public async Task<TrackSessionDTO> Update(int sessionId, UpdateTrackSessionDTO updateSessionDTO)
        {
            var userId = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
                throw new BusinessException("User has not claims", 401);

            var Instructorspec = new InstructorByUserIdSpecification(userId);
            var Instructor = await unitOfWork.Repository<Instructor>().GetById(Instructorspec);

            if (Instructor is null)
                throw new BusinessException("Instructor not found", 404);

            var sessionspec = new GetTrackbySessionIdSpecification(sessionId);
            var session=await unitOfWork.Repository<TrackSession>().GetById(sessionspec);

            if(session is null)
                throw new BusinessException("Session not found", 404);

            if (session.CreatedByInstructorId != Instructor.Id)
                throw new BusinessException("You are not allowed to update this session.",403);

            mapper.Map(updateSessionDTO,session);

            await unitOfWork.Repository<TrackSession>().Update(session);
            await unitOfWork.CompleteChanges();

            return mapper.Map<TrackSessionDTO>(session);


        }

        public async Task<TrackSessionDTO> Complete(int sessionId)
        {
            var userId = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
                throw new BusinessException("User has not claims", 401);

            var Instructorspec = new InstructorByUserIdSpecification(userId);
            var Instructor = await unitOfWork.Repository<Instructor>().GetById(Instructorspec);

            if (Instructor is null)
                throw new BusinessException("Instructor not found", 404);

            var sessionspec = new GetTrackbySessionIdSpecification(sessionId);
            var session = await unitOfWork.Repository<TrackSession>().GetById(sessionspec);

            if (session is null)
                throw new BusinessException("Session not found", 404);

            if (session.CreatedByInstructorId != Instructor.Id)
                throw new BusinessException("You are not allowed to update this session.", 403);

           session.IsCompleted= true;

            await unitOfWork.Repository<TrackSession>().Update(session);
            await unitOfWork.CompleteChanges();

            return mapper.Map<TrackSessionDTO>(session);
        }

      
        

        public async Task<IEnumerable<TrackSessionDTO>> GetMyStudentSessions()
        {
            var userId = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
                throw new BusinessException("User has not claims", 401);

            var Studentspec = new GetStudentbyCurrentUserIdSpecification(userId);
            var Student = await unitOfWork.Repository<Student>().GetById(Studentspec);

            if (Student is null)
                throw new BusinessException("Student not found", 404);

            var sessionsSpec =new GetSessionsByStudentIdSpecification(Student.Id);

            var sessions = await unitOfWork.Repository<TrackSession>().GetAll(sessionsSpec);

            return mapper.Map<IEnumerable<TrackSessionDTO>>(sessions);

        }

        
    }
}
