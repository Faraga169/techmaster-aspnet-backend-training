using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingCenter.DAL.Persistent;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.Interfaces;

namespace TrainingCenter.DAL.Repositories.Implementations
{
    public class StudentRepository(AppDbContext dbContext) : IStudentRepository
    {
        public async Task<IEnumerable<Student>> GetAll()
        {
            var Students = await dbContext.Students.AsNoTracking().ToListAsync();
            return Students;
        }


        public async Task<Student?> GetById(int id)
        {
            var Student = await dbContext.Students.FindAsync(id);
            return Student;
        }

        public async Task<int> Create(Student student)
        {
             await dbContext.Students.AddAsync(student);         
           return  await dbContext.SaveChangesAsync();
           
        }

        public async Task<int> Update(Student student)
        {
             dbContext.Update(student);
            return await dbContext.SaveChangesAsync();

        }

        public async Task<bool> Delete(int id)
        {
            var Student = await dbContext.Students.FindAsync(id);
            if (Student is null)
                return false;

            Student.IsDeleted = true;
            await dbContext.SaveChangesAsync();
            return true;
        }

        
       

       
    }
}
