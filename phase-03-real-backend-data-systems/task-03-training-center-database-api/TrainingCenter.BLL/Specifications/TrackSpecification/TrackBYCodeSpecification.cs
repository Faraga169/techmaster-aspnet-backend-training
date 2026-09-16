using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.TrackSpecification
{
    public class TrackBYCodeSpecification:BaseSpecification<TrainingTrack>
    {
        public TrackBYCodeSpecification(string code)
        {
            AddCriteria(t => t.Code == code);
        }
    }
}
