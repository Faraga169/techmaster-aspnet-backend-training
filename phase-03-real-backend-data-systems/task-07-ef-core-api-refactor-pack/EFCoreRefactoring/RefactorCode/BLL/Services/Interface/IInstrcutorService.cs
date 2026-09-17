using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.BLL.DTOS.Instructor;
using TrainingCenter.BLL.DTOS.Track;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.Services.Interface
{
    public interface IInstrcutorService
    {
         public Task<IEnumerable<InstructorDTO>> GetAll();

        public Task<InstructorDetailsDTO> GetById(int id);

        public Task<InstructorDTO> Create(CreateInstructorDTO instructor);

        public Task<InstructorDTO> Update(UpdateInstructorDTO instructor);

        public Task<IEnumerable<TrackDTO>> GetTracksByInstructorId(int id);
    }
}
