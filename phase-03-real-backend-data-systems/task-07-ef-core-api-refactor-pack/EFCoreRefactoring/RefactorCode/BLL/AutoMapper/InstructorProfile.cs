using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TrainingCenter.BLL.DTOS.Instructor;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.AutoMapper
{
    public class InstructorProfile:Profile
    {
        public InstructorProfile()
        {
            CreateMap<Instructor, InstructorDTO>().ReverseMap();
            CreateMap<Instructor, InstructorDetailsDTO>();
            CreateMap<CreateInstructorDTO, Instructor>();
            CreateMap<UpdateInstructorDTO, Instructor>();
        }
       

    }
}
