using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.TrackSpecification
{
    public class TrackByIdSpecification:BaseSpecification<TrainingTrack>
    {
        public TrackByIdSpecification(int id)
        {
            AddInclude(t => t.Instructor!);
            AddCriteria(t => t.Id == id);
        }
    }
}
