using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.BLL.DTOS;
using TrainingCenter.BLL.DTOS.Enrollment;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Services.Interface
{
    public interface IEnrollmentService
    {
        public Task<PaginatedResult<EnrollmentDTO>> GetAll(EnrollmentStatus? status,int? trackid,int? studentid,PaymentStatus? paymentStatus, int pagenumber = 1, int pagesize = 5);

        public Task<EnrollmentDTO> Create(CreateEnrollDTO enroll);

        public Task<bool> Delete(int id);
    }
}
