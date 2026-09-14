using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
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


        public Task<IEnumerable<Enrollment>> GetAll(EnrollmentStatus? status, int? trackId, int? StudentId, PaymentStatus? PaymentStatus);

        public Task<Enrollment?> GetByIdWithDetails(int id);

        public Task<IEnumerable<Enrollment>> GetEnrollmentsbyStudentId(int studentid);

        public Task<IEnumerable<Student>> GetStudentsByTrackId(int trackid);



    }
}
