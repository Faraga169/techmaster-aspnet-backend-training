using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.BLL.DTOS;
using TrainingCenter.BLL.DTOS.Student;

namespace TrainingCenter.BLL.Services.Interface
{
    public interface IStudentService
    {
        public Task<PaginatedResult<StudentDTO>> GetAll(string?sreachbyName,bool? IsActive, int pagenumber=1,int pagesize=5);

        public Task<StudentEnrollmentDTO> GetById(int id);

        public Task<StudentDTO> Create(CreateStudentDTO student);

        public Task<StudentDTO> Update(UpdateStudentDTO student);

        public Task<bool> Delete(int id);
    }
}
