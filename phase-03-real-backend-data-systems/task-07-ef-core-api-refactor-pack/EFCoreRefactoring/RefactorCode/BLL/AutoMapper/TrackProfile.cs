using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TrainingCenter.BLL.DTOS.Track;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.AutoMapper
{
    public class TrackProfile:Profile
    {
        public TrackProfile()
        {
            CreateMap<TrainingTrack,TrackDTO>().ForMember(dest=>dest.Level,opt=>opt.MapFrom(src=>src.Level.ToString()))
                                               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                                               .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.StartDate)))
                                               .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.EndDate))).ReverseMap(); 
            
            CreateMap<TrainingTrack, TrackDetailsDTO>().ForMember(dest=>dest.InstructorName,opt=>opt.MapFrom(src=>src.Instructor!.FullName))
                                                        .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level.ToString()))
                                                         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                                                         .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.StartDate)))
                                                         .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.EndDate)));

            CreateMap<CreateTrackDTO, TrainingTrack>().ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.ToDateTime(TimeOnly.MinValue)))
                                                        .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.ToDateTime(TimeOnly.MinValue)));
                                                        

            CreateMap<UpdateTrackDTO, TrainingTrack>().ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.ToDateTime(TimeOnly.MinValue)))
                                                        .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.ToDateTime(TimeOnly.MinValue))); ;
        }
    }
}
