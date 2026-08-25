using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.DTOS
{
    public class UpdateStudentRequest
    {

        [Required(ErrorMessage = "Full Name is Required")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "invalid Email  format")]
        public string Email { get; set; } = null!;

        [Phone]
        [Required(ErrorMessage = "PhoneNumber is Required")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "TrackName is Required")]
        public string TrackName { get; set; } = null!;

        public bool IsActive { get; set; }

        public string? GitHubProfileUrl { get; set; }

        public string? LinkedInProfileUrl { get; set; }
    }
}
