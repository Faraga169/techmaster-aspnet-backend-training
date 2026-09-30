using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StudentManagementAPI.Exceptions;
using TrainingCenter.BLL.DTOS.Instructor;
using TrainingCenter.BLL.DTOS.Track;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.BLL.Specifications.InstructorSpecification;
using TrainingCenter.BLL.Specifications.TrackSpecification;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Repositories.Interfaces;

namespace TrainingCenter.BLL.Services.Implementation
{
    public class InstructorService(IUnitOfWork unitOfWork, IMapper mapper) : IInstrcutorService
    {

        public async Task<IEnumerable<InstructorDTO>> GetAll()
        {
            var instructors =await unitOfWork.Repository<Instructor>().GetAll(null!);

            return mapper.Map<IEnumerable<InstructorDTO>>(instructors);
        }

        public async Task<InstructorDetailsDTO> GetById(int id)
        {
            var spec = new InstructorbyIdspecification(id);

            var instructor =await unitOfWork.Repository<Instructor>().GetById(spec);

            if (instructor is null)
                throw new BusinessException("Instructor not found", 404);

            return mapper.Map<InstructorDetailsDTO>(instructor);
        }

        public async Task<InstructorDTO> Create(CreateInstructorDTO dto)
        {

            var instructor = mapper.Map<Instructor>(dto);

            await unitOfWork.Repository<Instructor>().Create(instructor);
            await unitOfWork.CompleteChanges();

            return mapper.Map<InstructorDTO>(instructor);
        }

        public async Task<InstructorDTO> Update(UpdateInstructorDTO dto)
        {
            var spec = new InstructorbyIdspecification(dto.Id);

            var existingInstructor =await unitOfWork.Repository<Instructor>().GetById(spec);

            if (existingInstructor is null)
                throw new BusinessException("Instructor not found", 404);

            var instructor=mapper.Map<Instructor>(dto);

            await unitOfWork.Repository<Instructor>() .Update(instructor);

            await unitOfWork.CompleteChanges();

            return mapper.Map<InstructorDTO>(instructor);
        }

        public async Task<IEnumerable<TrackDTO>> GetTracksByInstructorId(int id)
        {
           
            var spec=new InstructorbyIdspecification(id);
            var instructor =await unitOfWork.Repository<Instructor>().GetById(spec);

            if (instructor is null)
                throw new BusinessException("Instructor not found", 404);
            var specins = new TrackByInstructorIdSpecification(id);
            var tracks =await unitOfWork.InstructorRepository().GetTracksByInstructorId(specins);

            return mapper.Map<IEnumerable<TrackDTO>>(tracks);
        }



    }
}
