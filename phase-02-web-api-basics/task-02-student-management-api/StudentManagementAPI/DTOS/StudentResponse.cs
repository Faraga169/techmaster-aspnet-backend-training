using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.DTOS
{
    public class StudentResponse
    {
        public Guid Id { get; set; }

     
        public string FullName { get; set; } = null!;

    
        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

     
        public string TrackName { get; set; } = null!;

        public bool IsActive { get; set; }

        public string? GitHubProfileUrl { get; set; }

        public string? LinkedInProfileUrl { get; set; }
    }
}
