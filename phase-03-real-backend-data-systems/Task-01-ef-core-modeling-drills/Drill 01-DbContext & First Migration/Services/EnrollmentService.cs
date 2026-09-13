using Drill_01_DbContext___First_Migration.Data;
using Drill_01_DbContext___First_Migration.DTOS;
using Microsoft.EntityFrameworkCore;

namespace Drill_01_DbContext___First_Migration.Services
{
    public class EnrollmentService(AppDbContext appContext) : IEnrollmentService
    {
        public IEnumerable<GetEnrollmentsDTO> GetAll()
        {
            var Enrollments = appContext.Enrollments.Include(e => e.Track).Include(e=>e.Student).Include(e=>e.PaymentSummary).ToList();

            var GetAllEnrollmentskDTO = Enrollments.Select(e => new GetEnrollmentsDTO()
            {
                TrackName=e.Track.Name,
                StudentName=e.Student.FullName,
                PaymentStatus=e.PaymentSummary.PaymentStatus.ToString(),
                RemainingAmount=e.PaymentSummary.RemainingAmount,
                TotalRequired=e.PaymentSummary.TotalRequired,
                TotalPaid=e.PaymentSummary.TotalPaid,
                EnrollmentDate=e.EnrollmentDate,
                FinalGrade=e.FinalGrade,
                Status=e.Status.ToString()    
                
            });

            return GetAllEnrollmentskDTO.ToList();
        }
    }
}
