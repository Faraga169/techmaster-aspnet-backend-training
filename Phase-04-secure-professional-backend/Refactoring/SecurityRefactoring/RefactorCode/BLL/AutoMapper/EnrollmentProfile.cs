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
            CreateMap<Enrollment, EnrollmentDTO>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                                                                .ForMember(dest => dest.TrainingTrackName, opt => opt.MapFrom(src => src.TrainingTrack!.Title))
                                                                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student!.FullName))
                                                                 .ForMember(dest => dest.EnrollmentDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.EnrollmentDate))).ReverseMap();
                               
            CreateMap<CreateEnrollDTO, Enrollment>();
           
        }
    }
}
