using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
    public class EnrollmentService(IUnitOfWork unitOfWork, IMapper mapper) : IEnrollmentService
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
            
            var studentspec = new StudentByIdSpecification(enroll.StudentId);
            var student = await unitOfWork.Repository<Student>().GetById(studentspec);

            if (student is null)
                throw new BusinessException("Student not found", 404);

            if(student.IsDeleted||student.IsActive)
                throw new BusinessException("Student not allow to make enrollment", 404);

            var trackSpec = new TrackByIdSpecification(enroll.TrainingTrackId);

            var track = await unitOfWork.Repository<TrainingTrack>().GetById(trackSpec);

            if (track is null)
                throw new BusinessException("Track not found", 404);

            var spec = new CheckduplicateofStudentEnrollment(enroll.StudentId, enroll.TrainingTrackId);

            var existingEnroll = await unitOfWork.Repository<Enrollment>().GetById(spec);

            if (existingEnroll is not null)
                throw new BusinessException("Student already in this track", 409);

            var speccapacity = new TrackCapacitySpecification(enroll.TrainingTrackId);
            var checkcapacity = await unitOfWork.Repository<TrainingTrack>().GetById(speccapacity);

            if (checkcapacity is null)
                throw new BusinessException("The Active Capacity is Full", 400);

            var enrollment = mapper.Map<Enrollment>(enroll);

            await unitOfWork.Repository<Enrollment>().Create(enrollment);

            await unitOfWork.CompleteChanges();

            return mapper.Map<EnrollmentDTO>(enrollment);

        }


        public async Task<EnrollmentDTO> Update(UpdateEnrollDTO enroll)
        {
            var spec = new EnrollByIdSpecification(enroll.Id);

            var existingEnroll = await unitOfWork.Repository<Enrollment>().GetById(spec);

            if (existingEnroll is null)
                throw new BusinessException("Enrollment is not found", 404);

            if (existingEnroll?.Status == EnrollmentStatus.Completed)
                throw new BusinessException("Enrollment status cannot be changes", 404);

            existingEnroll.Status = enroll.Status;

            await unitOfWork.Repository<Enrollment>().Update(existingEnroll);

            await unitOfWork.CompleteChanges();
            return mapper.Map<EnrollmentDTO>(existingEnroll);
        }

        public async Task<IEnumerable<EnrollmentDTO>> GetEnrollmentsbyStudentId(int id)
        {
            var spec = new EnrollmentbyStudentIdSpecification(id);

            var existingEnrollmentsbyStudentId = await unitOfWork.EnrollmentRepository().GetEnrollmentsbyStudentId(spec);

            if(!existingEnrollmentsbyStudentId.Any())
                throw new BusinessException("Student is not found in Enrollments", 404);

            var EnrollmentsofStudent= mapper.Map<IEnumerable<Enrollment>,IEnumerable<EnrollmentDTO>>(existingEnrollmentsbyStudentId);

            return EnrollmentsofStudent;


        }

        public async Task<IEnumerable<TrackStudentDto>> GetStudentsByTrackId(int id)
        {
            var spec = new StudentsBYtrackIdSpecification(id);

            var existingStudentsbytrack = await unitOfWork.EnrollmentRepository().GetStudentsByTrackId(spec);

            if (!existingStudentsbytrack.Any())
                throw new BusinessException("No Students is enrolled in track", 404);

            var Studentsbytrack = mapper.Map<IEnumerable<Enrollment>, IEnumerable<TrackStudentDto>>(existingStudentsbytrack);

            return Studentsbytrack;

        }


    }
}
