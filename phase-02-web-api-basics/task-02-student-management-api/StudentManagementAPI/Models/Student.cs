using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;

namespace StudentManagementAPI.Models
{
    public class Student
    {
        
        public Guid Id { get; set; }

      
        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int PhoneNumber { get; set; }

       
        public string TrackName { get; set; } = null!;

        public bool IsActive { get; set; }

        public string? GitHubProfileUrl { get; set; }

        public string? LinkedInProfileUrl { get; set; }
    }
}
