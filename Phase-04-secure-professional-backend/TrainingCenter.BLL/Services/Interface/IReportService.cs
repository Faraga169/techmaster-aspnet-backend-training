using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Repositories.ReportModels;

namespace TrainingCenter.BLL.Services.Interface
{
    public interface IReportService
    {
        public Task<TrackLevelSummary> GetTrackLevelSummary(int id);
    }

}
