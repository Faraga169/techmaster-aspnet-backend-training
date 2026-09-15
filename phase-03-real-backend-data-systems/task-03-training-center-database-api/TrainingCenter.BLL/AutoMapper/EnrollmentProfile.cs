using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TrainingCenter.BLL.DTOS.Enrollment;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.AutoMapper
{
    public class EnrollmentProfile:Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<Enrollment, EnrollmentDTO>();
            CreateMap<Enrollment, EnrollmentDetailsDTO>();
            CreateMap<CreateEnrollDTO, Enrollment>();
            CreateMap<UpdateEnrollDTO, Enrollment>();
        }
    }
}
