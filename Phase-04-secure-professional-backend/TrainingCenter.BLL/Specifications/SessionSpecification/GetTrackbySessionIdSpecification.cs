using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.SessionSpecification
{
    public class GetTrackbySessionIdSpecification:BaseSpecification<TrackSession>
    {
        public GetTrackbySessionIdSpecification(int sessionId)
        {
            AddCriteria(s => s.Id == sessionId);
            AddInclude(s => s.TrainingTrack);
        }
    }
}
