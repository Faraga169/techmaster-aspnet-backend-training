using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using StudentManagementAPI.Exceptions;
using TrainingCenter.BLL.DTOS.Enrollment;
using TrainingCenter.BLL.DTOS.Student;
using TrainingCenter.BLL.DTOS.Track;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.BLL.Specifications.EnrollmentSpecification;
using TrainingCenter.BLL.Specifications.StudentSpecifications;
using TrainingCenter.BLL.Specifications.TrackSpecification;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.Implementations;
using TrainingCenter.DAL.Repositories.Interfaces;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Services.Implementation
{
    public class EnrollmentService(IUnitOfWork unitOfWork, IMapper mapper,IHttpContextAccessor contextAccessor, ILogger<EnrollmentService> logger,IActivityLogService activityLogService) : IEnrollmentService
    {


        public async Task<IEnumerable<EnrollmentDTO>> GetAll(EnrollmentStatus? status, int? trackid, int? studentid, PaymentStatus? paymentStatus)
        {
            var EnrollSpecification = new EnrollmentBystatusandtrackidandstudentidandpaymentstatusspecification(status, trackid, studentid, paymentStatus);
            var GetAllEnrollments = await unitOfWork.Repository<Enrollment>().GetAll(EnrollSpecification);
            var EnrollmetsDTO = mapper.Map<IEnumerable<Enrollment>, IEnumerable<EnrollmentDTO>>(GetAllEnrollments);
           
            return EnrollmetsDTO;
        }


        public async Task<EnrollmentDetailsDTO> GetById(int id)
        {

            var EnrollSpecification = new EnrollByIdSpecification(id);
            var GetEnrollment = await unitOfWork.Repository<Enrollment>().GetById(EnrollSpecification);
            if (GetEnrollment is null)
                throw new BusinessException("Enrollment is not found", 404);
            var EnrollmentDetailsDTO = mapper.Map<Enrollment, EnrollmentDetailsDTO>(GetEnrollment);
            return EnrollmentDetailsDTO;
        }

        public async Task<EnrollmentDTO> Create(CreateEnrollDTO enroll)
        {
            var userId = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = contextAccessor.HttpContext.User.IsInRole("Admin");
            if (userId is null)
                throw new BusinessException("User Claims not found", 401);


            if (!isAdmin)
            {
                var currentuser = new GetStudentbyCurrentUserIdSpecification(userId);

                var userspec = await unitOfWork.Repository<Student>()
                    .GetById(currentuser);

                if (userspec is null)
                    throw new BusinessException("Student not found", 404);

                if (enroll.StudentId != userspec.Id)
                    throw new BusinessException(
                        "You have not access to assign another student",
                        403);
            }
           



            var studentspec = new StudentByIdSpecification(enroll.StudentId!.Value);
            var student = await unitOfWork.Repository<Student>().GetById(studentspec);

           

            if (student is null)
                throw new BusinessException("Student not found", 404);

            if (student.IsDeleted || !student.IsActive)
                throw new BusinessException("Student not allow to make enrollment", 404);

           

            var trackSpec = new TrackByIdSpecification(enroll.TrainingTrackId!.Value);

            var track = await unitOfWork.Repository<TrainingTrack>().GetById(trackSpec);

            if (track is null)
                throw new BusinessException("Track not found", 404);

            if(track.Status==TrainingStatus.Cancelled|| track.Status == TrainingStatus.Completed)
                throw new BusinessException("Cannot Enroll in Track was cancelled or completed", 400);

            var spec = new CheckduplicateofStudentEnrollment(enroll.StudentId.Value, enroll.TrainingTrackId.Value);

            var existingEnroll = await unitOfWork.Repository<Enrollment>().GetById(spec);



            if (existingEnroll is not null)
                throw new BusinessException("Student already in this track", 409);

            var speccapacity = new TrackCapacitySpecification(enroll.TrainingTrackId.Value);
            var checkcapacity = await unitOfWork.Repository<TrainingTrack>().GetById(speccapacity);

            if (checkcapacity is null)
                throw new BusinessException("The Active Capacity is Full", 400);



            await unitOfWork.BeginTransactionAsync();

            try
            {
                var enrollment = mapper.Map<Enrollment>(enroll);

                await unitOfWork.Repository<Enrollment>()
                    .Create(enrollment);

               
                await unitOfWork.CompleteChanges();

              
                await activityLogService.LogAsync(
                    new ActivityLog
                    {
                        Action = "EnrollmentRequested",
                        EntityName = "Enrollment",
                        EntityId = enrollment.Id.ToString(),
                        Description =
                            $"Student {enrollment.StudentId} requested enrollment in track {enrollment.TrainingTrackId}"
                    });

                await unitOfWork.CompleteChanges();

                await unitOfWork.CommitTransactionAsync();

                var enrollSpec =
                    new EnrollByIdSpecification(enrollment.Id);

                var createdEnrollment =
                    await unitOfWork.Repository<Enrollment>()
                        .GetById(enrollSpec);

                return mapper.Map<EnrollmentDTO>(createdEnrollment);
            }
            catch
            {
                await unitOfWork.RollbackTransactionAsync();
                throw;
            }

        }


        public async Task<EnrollmentDTO> Update(int id,UpdateEnrollDTO enroll)
        {
            var userId = contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId is null)
                throw new BusinessException("User Claims not found", 401);


            var spec = new EnrollByIdSpecification(id);

            var existingEnroll = await unitOfWork.Repository<Enrollment>().GetById(spec);

            if (existingEnroll is null)
                throw new BusinessException("Enrollment is not found", 404);

            if (existingEnroll?.Status == EnrollmentStatus.Completed)
                throw new BusinessException("Enrollment status cannot be changed after completion.",400);

            var oldStatus = existingEnroll!.Status;

            existingEnroll.Status = enroll.Status;
            await unitOfWork.Repository<Enrollment>().Update(existingEnroll);
            await activityLogService.LogAsync(
   new ActivityLog
   {
       Action = "EnrollmentStatusUpdated",
       EntityName = "Enrollment",
       EntityId = existingEnroll.Id.ToString(),
       Description = $"Enrollment status changed from {oldStatus} to {existingEnroll.Status}",
       Metadata = JsonSerializer.Serialize(new
       {
           OldStatus = oldStatus.ToString(),
           NewStatus = existingEnroll.Status.ToString()
       })
   });
            await unitOfWork.CompleteChanges();
            logger.LogInformation("Enrollment {EnrollmentId} status changed from {OldStatus} to {NewStatus} by User {UserId}.",
    existingEnroll.Id,
    oldStatus.ToString(),
    existingEnroll.Status.ToString(),
    userId);

            var enrollspec = new EnrollByIdSpecification(existingEnroll.Id);
            var updateEnrollment = await unitOfWork.Repository<Enrollment>().GetById(enrollspec);

            return mapper.Map<EnrollmentDTO>(updateEnrollment);
        }

        public async Task<IEnumerable<EnrollmentDTO>> GetEnrollmentsbyStudentId(int id)
        {
            var userId = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = contextAccessor.HttpContext.User.IsInRole("Admin");
            if (userId is null)
                throw new BusinessException("User Claims not found", 401);

            var StudentSpecification = new StudentByIdSpecification(id);
            var Student = await unitOfWork.Repository<Student>().GetById(StudentSpecification);

            if (Student is null)
                throw new BusinessException("Student is not found", 404);

            if (!isAdmin && Student.UserId != userId)
                throw new BusinessException("You are not allowed to see these enrollments.", 403);

            var spec = new EnrollmentbyStudentIdSpecification(id);

            var Enrollments = await unitOfWork.EnrollmentRepository().GetEnrollmentsbyStudentId(spec);

            var EnrollmentsofStudent= mapper.Map<IEnumerable<Enrollment>,IEnumerable<EnrollmentDTO>>(Enrollments);

            return EnrollmentsofStudent;


        }

        public async Task<IEnumerable<EnrollmentDTO>> GetMyEnrollments()
        {
            var userId = contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId is null)
                throw new BusinessException("User claims not found.", 401);

            var student = await unitOfWork.Repository<Student>().GetById(new StudentByUserIdSpecification(userId));

            if (student is null)
                throw new BusinessException("Student profile not found.", 404);

            return await GetEnrollmentsbyStudentId(student.Id);
        }

        public async Task<IEnumerable<TrackStudentDto>> GetStudentsByTrackId(int id)
        {
            var userId = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = contextAccessor.HttpContext.User.IsInRole("Admin");
            if (userId is null)
                throw new BusinessException("User Claims not found", 401);

            var spectrack = new TrackByIdSpecification(id);
            var existingtrack=await unitOfWork.Repository<TrainingTrack>().GetById(spectrack);

            if (existingtrack is null)
                throw new BusinessException("Track not found",404);

            if (existingtrack?.Instructor?.UserId != userId&&!isAdmin)
                throw new BusinessException("You are not allowed to access Students in this track.", 403);

            var spec = new StudentsBYtrackIdSpecification(id);

            var existingStudentsbytrack = await unitOfWork.EnrollmentRepository().GetStudentsByTrackId(spec);

            var Studentsbytrack = mapper.Map<IEnumerable<Enrollment>, IEnumerable<TrackStudentDto>>(existingStudentsbytrack);

            return Studentsbytrack;

        }


    }
}
