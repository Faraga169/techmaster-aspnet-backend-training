using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Specifications;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenter.DAL.Repositories.Interfaces
{
    public interface IEnrollmentRepository:IGenericRepository<Enrollment>
    {
        //GET /api/enrollments Return enrollments with filters: status, trackId, studentId, paymentStatus.
        //GET /api/enrollments/{id} Return enrollment details with student, track and payments.
        //POST / api / enrollments Enroll student in track using duplicate and capacity rules.
        //PUT /api/enrollments/{id
        //}/ status Change enrollment status using valid transitions.
        //GET / api / students /{ id}/ enrollments Return student enrollment history.
        //GET /api/tracks/{id}/ students

        public Task<Enrollment?> GetByIdWithDetails(ISpecification<Enrollment> spec);

        public Task<IEnumerable<Enrollment>> GetEnrollmentsbyStudentId(ISpecification<Enrollment> spec);

        public Task<IEnumerable<Student>> GetStudentsByTrackId(ISpecification<Enrollment> spec);



    }
}
