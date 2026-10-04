using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StudentManagementAPI.Exceptions;
using TrainingCenter.BLL.DTOS;
using TrainingCenter.BLL.DTOS.Enrollment;
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
    public class EnrollmentService(IUnitOfWork unitOfWork, IMapper mapper) : IEnrollmentService
    {


        public async Task<PaginatedResult<EnrollmentDTO>> GetAll(EnrollmentStatus? status, int? trackid, int? studentid, PaymentStatus? paymentStatus,int pagenumber=1,int pagesize=5)
        {

            if (pagenumber < 1)
                throw new BusinessException("Page number must be greater than 0", 400);

            if (pagesize < 1)
                throw new BusinessException("Page size must be greater than 0", 400);

            var EnrollSpecification = new EnrollmentBystatusandtrackidandstudentidandpaymentstatusspecification(status, trackid, studentid, paymentStatus);
            var GetAllEnrollments = await unitOfWork.Repository<Enrollment>().GetAll(EnrollSpecification);
            var EnrollmetsDTO = mapper.Map<IEnumerable<Enrollment>, IEnumerable<EnrollmentDTO>>(GetAllEnrollments);
            
            var TotalCount = await unitOfWork.Repository<Enrollment>().Count(EnrollSpecification);

            return new PaginatedResult<EnrollmentDTO>
            {
                Items = EnrollmetsDTO,
                PageNumber = pagenumber,
                PageSize = pagesize,
                TotalCount = TotalCount,
                TotalPages = (int)Math.Ceiling(
            TotalCount / (double)pagesize)


            };
        }

        public async Task<EnrollmentDTO> Create(CreateEnrollDTO enroll)
        {
            
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

            if(track.Status==TrainingStatus.Cancelled)
                throw new BusinessException("Cannot Enroll in Track was cancelled", 400);

            var spec = new CheckduplicateofStudentEnrollment(enroll.StudentId.Value, enroll.TrainingTrackId.Value);

            var existingEnroll = await unitOfWork.Repository<Enrollment>().GetById(spec);

            if (existingEnroll is not null)
                throw new BusinessException("Student already in this track", 409);

            var speccapacity = new TrackCapacitySpecification(enroll.TrainingTrackId.Value);
            var checkcapacity = await unitOfWork.Repository<TrainingTrack>().GetById(speccapacity);

            if (checkcapacity is null)
                throw new BusinessException("The Active Capacity is Full", 400);

            var enrollment = mapper.Map<Enrollment>(enroll);

          

            await unitOfWork.Repository<Enrollment>().Create(enrollment);

            await unitOfWork.CompleteChanges();

            var enrollspec = new EnrollByIdSpecification(enrollment.Id);
            var createdEnrollment =await unitOfWork.Repository<Enrollment>().GetById(enrollspec);


            return mapper.Map<EnrollmentDTO>(createdEnrollment);

        }


        public async Task<bool> Delete(int id)
        {
            var spec = new EnrollByIdSpecification(id);

            var existingEnrollment = await unitOfWork.Repository<Enrollment>().GetById(spec);

            if (existingEnrollment is null)
                throw new BusinessException("Enrollment not found", 404);

            existingEnrollment.IsDeleted = true;
            existingEnrollment.Status = EnrollmentStatus.Cancelled;
            await unitOfWork.Repository<Student>().Delete(id);
            await unitOfWork.CompleteChanges();
            return true;
        }

    }
}
