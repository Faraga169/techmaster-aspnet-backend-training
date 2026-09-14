using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingCenter.DAL.Persistent;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.Interfaces;

namespace TrainingCenter.DAL.Repositories.Implementations
{
    public class EnrollmentRepository(AppDbContext dbContext) : IEnrollmentRepository
    {

        public async Task<IEnumerable<Enrollment>> GetAll(EnrollmentStatus? status, int? trackId, int? StudentId, PaymentStatus? PaymentStatus)
        {
            var query = dbContext.Enrollmets.AsNoTracking().AsQueryable();

            if (status is not null)
                query = query.Where(e => e.Status==status.Value);
            if(trackId is not null)
                query = query.Where(e => e.TrainingTrackId == trackId);
            if (StudentId is not null) 
                query = query.Where(e => e.StudentId == StudentId);
            if(PaymentStatus is not null)
                query = query.Where(e => e.Payments.Any(p=>p.Status==PaymentStatus.Value));

            return await query.ToListAsync();

        }


        public async Task<Enrollment?> GetById(int id)
        {
            var Enrollment = await dbContext.Enrollmets.Include(e=>e.Payments).Include(e=>e.TrainingTrack).Include(e=>e.Student).FirstOrDefaultAsync(e=>e.Id==id);
            return Enrollment;
        }
        

        public async Task<int> Create(Enrollment enrollment)
        {
            await dbContext.Enrollmets.AddAsync(enrollment);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(Enrollment enrollment)
        {
            dbContext.Update(enrollment);
            return await dbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<Enrollment>> GetEnrollmentsbyStudentId(int studentid)
        {
            var EnrollmentsByStudentId = await dbContext.Enrollmets.Where(e => e.StudentId == studentid).ToListAsync();
            return EnrollmentsByStudentId;
        }

        public async Task<IEnumerable<Student>> GetStudentsEnrollbyTrackId(int trackid)
        {
            var EnrollmentsByStudentId = await dbContext.Students.Where(s=>s.Enrollments.Any(e=>e.TrainingTrackId==trackid)).ToListAsync();
            return EnrollmentsByStudentId;
        }

       
    }
}
