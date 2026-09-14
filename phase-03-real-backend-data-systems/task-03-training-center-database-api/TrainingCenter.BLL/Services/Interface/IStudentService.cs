using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.BLL.DTOS.Student;

namespace TrainingCenter.BLL.Services.Interface
{
    public interface IStudentService
    {
        public Task<IEnumerable<StudentDTO>> GetAll(string?sreachbyName,bool? IsActive);

        public Task<StudentEnrollmentDTO> GetById(int id);

        public Task Create(CreateStudentDTO student);

        public Task Update(UpdateStudentDTO student);

        public Task<bool> Delete(int id);
    }
}
