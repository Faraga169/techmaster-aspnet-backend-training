using StudentManagementAPI.Models;

namespace StudentManagementAPI.Seeding
{
    public static class StudentSeeding
    {
        public static List<Student> Students { get; } =new List<Student>
        {
            
                new Student
                {
                    Id = Guid.NewGuid(),
                    FullName = "Ahmed Mohamed",
                    Email = "ahmed.mohamed@example.com",
                    PhoneNumber = 1012345678,
                    TrackName = "Full Stack .NET",
                    IsActive = true,
                    GitHubProfileUrl = "https://github.com/ahmedmohamed",
                    LinkedInProfileUrl = "https://www.linkedin.com/in/ahmedmohamed"
                },

                new Student
                {
                    Id = Guid.NewGuid(),
                    FullName = "Mohamed Ali",
                    Email = "mohamed.ali@example.com",
                    PhoneNumber = 1123456789,
                    TrackName = "Backend .NET",
                    IsActive = true,
                    GitHubProfileUrl = "https://github.com/mohamedali",
                    LinkedInProfileUrl = "https://www.linkedin.com/in/mohamedali"
                },

                new Student
                {
                    Id = Guid.NewGuid(),
                    FullName = "Sara Hassan",
                    Email = "sara.hassan@example.com",
                    PhoneNumber = 1023456789,
                    TrackName = "Frontend Angular",
                    IsActive = true,
                    GitHubProfileUrl = "https://github.com/sarahassan",
                    LinkedInProfileUrl = "https://www.linkedin.com/in/sarahassan"
                },

                new Student
                {
                    Id = Guid.NewGuid(),
                    FullName = "Omar Khaled",
                    Email = "omar.khaled@example.com",
                    PhoneNumber = 1112345678,
                    TrackName = "Full Stack .NET",
                    IsActive = false,
                    GitHubProfileUrl = "https://github.com/omarkhaled",
                    LinkedInProfileUrl = "https://www.linkedin.com/in/omarkhaled"
                },

                new Student
                {
                    Id = Guid.NewGuid(),
                    FullName = "Mariam Ahmed",
                    Email = "mariam.ahmed@example.com",
                    PhoneNumber = 1098765432,
                    TrackName = "Backend .NET",
                    IsActive = true,
                    GitHubProfileUrl = "https://github.com/mariamahmed",
                    LinkedInProfileUrl = "https://www.linkedin.com/in/mariamahmed"
                }
            };

        
    }
}