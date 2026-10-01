using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StudentManagementAPI.Exceptions;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.BLL.Specifications.TrackSpecification;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Repositories.Implementations;
using TrainingCenter.DAL.Repositories.Interfaces;
using TrainingCenter.DAL.Repositories.ReportModels;

namespace TrainingCenter.BLL.Services.Implementation
{
    public class ReportService(IHttpContextAccessor contextAccessor,IUnitOfWork unitOfWork):IReportService
    {
        public async Task<TrackLevelSummary> GetTrackLevelSummary(int id)
        {
            var user = contextAccessor.HttpContext!.User;

            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId is null)
                throw new BusinessException("User claims not found.", 401);

            var isAdmin = user.IsInRole("Admin");

            var spec = new TrackByIdSpecification(id);
            var track = await unitOfWork.Repository<TrainingTrack>().GetById(spec);


            if (track is null)
                throw new BusinessException("Track not found.", 404);

            if (!isAdmin && track.Instructor?.UserId != userId)
                throw new BusinessException("You are not allowed to access this track.",403);

            var result = await unitOfWork.ReportRepository().GetTrackLevelSummary(id);

            return result!;
        }
    }
}
