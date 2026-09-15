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
                                               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            
            CreateMap<TrainingTrack, TrackDetailsDTO>().ForMember(dest=>dest.InstructorName,opt=>opt.MapFrom(src=>src.Instructor!.FullName))
                                                        .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level.ToString()))
                                                         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<CreateTrackDTO, TrainingTrack>();

            CreateMap<UpdateTrackDTO, TrainingTrack>();
        }
    }
}
