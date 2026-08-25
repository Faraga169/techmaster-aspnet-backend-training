namespace StudentManagementAPI.DTOS
{
    public class StudentStatsResponse
    {
        public int TotalStudents { get; set; }

        public int ActiveStudents { get; set; }

        public int InActiveStudents { get; set; }

        public List<TrackStatsResponse> CountByTrack { get; set; }=new List<TrackStatsResponse>();


    }
}
