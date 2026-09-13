namespace Drill_01_DbContext___First_Migration.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public ICollection<TrainingTrack> TrainingTracks { get; set; } = new HashSet<TrainingTrack>();


    }
}
