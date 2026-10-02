using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TrainingCenter.BLL.DTOS.Session;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.AutoMapper
{
    public class TrackSessionProfile:Profile
    {
        public TrackSessionProfile()
        {
            CreateMap<TrackSession, TrackSessionDTO>().ForMember(dest => dest.TrackName, opt => opt.MapFrom(src => src.TrainingTrack.Title));
            CreateMap<CreateSessionDTO, TrackSession>().ReverseMap();
            CreateMap<UpdateTrackSessionDTO, TrackSession>().ReverseMap();
        }
    }
}
