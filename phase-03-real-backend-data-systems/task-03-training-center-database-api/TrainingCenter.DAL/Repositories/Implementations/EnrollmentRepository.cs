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
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.DAL.Repositories.Implementations
{
    public class EnrollmentRepository(AppDbContext dbContext) : GenericRepository<Enrollment>(dbContext),IEnrollmentRepository
    {

        //public async Task<IEnumerable<Enrollment>> GetAll(ISpecification<Enrollment> spec)
        //{
        //    var query = dbContext.Enrollmets.AsNoTracking().AsQueryable();

        //    query = SpecificationEvaluator<Enrollment>.GetQuery(query, spec);

        //    return await query.ToListAsync();

        //}

        //public async Task<Enrollment?> GetByIdWithDetails(ISpecification<Enrollment> spec)
        //{
        //    var query =  dbContext.Enrollmets.AsNoTracking();
        //    query= SpecificationEvaluator<Enrollment>.GetQuery(query, spec);
        //    return await query.FirstOrDefaultAsync();
        //}
        
        public async Task<IEnumerable<Enrollment>> GetEnrollmentsbyStudentId(ISpecification<Enrollment> spec)
        {
            var query = dbContext.Enrollmets.AsNoTracking();
            query = SpecificationEvaluator<Enrollment>.GetQuery(query, spec);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentsByTrackId(ISpecification<Student> spec)
        {
            var query = dbContext.Students.AsNoTracking();
            query = SpecificationEvaluator<Student>.GetQuery(query, spec);
            return await query.ToListAsync();
            //var EnrollmentsByStudentId = await dbContext.Students.AsNoTracking().Where(s=>s.Enrollments.Any(e=>e.TrainingTrackId==trackid)).ToListAsync();
            //return EnrollmentsByStudentId;
        }

       
    }
}
