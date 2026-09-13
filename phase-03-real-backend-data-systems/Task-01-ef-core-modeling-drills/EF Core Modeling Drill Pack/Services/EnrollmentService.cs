using Drill_01_DbContext___First_Migration.Data;
using Drill_01_DbContext___First_Migration.DTOS;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Exceptions;

namespace Drill_01_DbContext___First_Migration.Services
{
    public class EnrollmentService(AppDbContext appContext) : IEnrollmentService
    {
        public PaginationResultDTO GetAll(int pagesize=5,int pagenumber=1)
        {
            if(pagesize<1 ||pagesize>50)
                throw new BusinessException("pagesize must be between 1 and 50", 400);

            if(pagenumber<1)
                throw new BusinessException("pagenumber must be positive", 400);


            var Enrollments = appContext.Enrollments.Include(e => e.Track).Include(e=>e.Student).Include(e=>e.PaymentSummary);
            
            if (Enrollments.Count() == 0) {

                throw new BusinessException("Enrollments not found", 404);


            }


               
            var totalPages = (int)Math.Ceiling((decimal)Enrollments.Count()/pagesize);

            if(pagenumber>totalPages)
                throw new BusinessException("pagenumber must be less than totalpages or equal", 400);

            var Enrollmentpagination = Enrollments.Skip((pagenumber - 1) * pagesize).Take(pagesize).ToList();


            var PaginationDTO = new PaginationResultDTO()
            {
                pageNumber=pagenumber,
                pageSize=pagesize,
                TotalCount=Enrollments.Count(),
                TotalPages=totalPages,
                items = Enrollmentpagination.Select(e => new GetEnrollmentsDTO() {

                    TrackName = e.Track.Name,
                    StudentName = e.Student.FullName,
                    PaymentStatus = e.PaymentSummary.PaymentStatus.ToString(),
                    RemainingAmount = e.PaymentSummary.RemainingAmount,
                    TotalRequired = e.PaymentSummary.TotalRequired,
                    TotalPaid = e.PaymentSummary.TotalPaid,
                    EnrollmentDate = e.EnrollmentDate,
                    FinalGrade = e.FinalGrade,
                    Status = e.Status.ToString()
                })
                

            };

            return PaginationDTO;
        }
    }
}
