using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.BLL.DTOS.Enrollment;
using TrainingCenter.BLL.DTOS.Student;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Services.Interface
{
    public interface IEnrollmentService
    {
        public Task<IEnumerable<EnrollmentDTO>> GetAll(EnrollmentStatus? status,int? trackid,int? studentid,PaymentStatus? paymentStatus);

        public Task<EnrollmentDetailsDTO> GetById(int id);

        public Task<EnrollmentDTO> Create(CreateEnrollDTO enroll);

        public Task<EnrollmentDTO> Update(UpdateEnrollDTO enroll);

        public Task<IEnumerable<EnrollmentDTO>> GetEnrollmentsbyStudentId(int id);

        public Task<IEnumerable<TrackStudentDto>> GetStudentsByTrackId(int id);
    }
}
