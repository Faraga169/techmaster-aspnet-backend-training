using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;

namespace TrainingCenter.DAL.Persistent.Dataseeding
{
    public static class Seeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Students
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FullName = "Ahmed Farag",
                    Email = "ahmed@example.com",
                    PhoneNumber = "01000000000",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Student
                {
                    Id = 2,
                    FullName = "Mohamed Ali",
                    Email = "mohamed@example.com",
                    PhoneNumber = "01100000000",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                }
                ,
                new Student
                {
                    Id = 3,
                    FullName = "Omar Khaled",
                    Email = "omar@example.com",
                    PhoneNumber = "01200000000",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 9, 1),
                    IsDeleted = false
                },
new Student
{
    Id = 4,
    FullName = "Youssef Ahmed",
    Email = "youssef@example.com",
    PhoneNumber = "01011111111",
    IsActive = true,
    CreatedAt = new DateTime(2026, 9, 1),
    IsDeleted = false
},
new Student
{
    Id = 5,
    FullName = "Mahmoud Hassan",
    Email = "mahmoud@example.com",
    PhoneNumber = "01122222222",
    IsActive = true,
    CreatedAt = new DateTime(2026, 9, 1),
    IsDeleted = false
},
new Student
{
    Id = 6,
    FullName = "Mostafa Adel",
    Email = "mostafa@example.com",
    PhoneNumber = "01233333333",
    IsActive = true,
    CreatedAt = new DateTime(2026, 9, 1),
    IsDeleted = false
},
new Student
{
    Id = 7,
    FullName = "Karim Samir",
    Email = "karim@example.com",
    PhoneNumber = "01044444444",
    IsActive = true,
    CreatedAt = new DateTime(2026, 9, 1),
    IsDeleted = false
}
            );

            // Instructors
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor
                {
                    Id = 1,
                    FullName = "Ahmed Hassan",
                    Email = "ahmed.hassan@example.com",
                    Specialization = ".NET Backend",
                    Bio = "Senior .NET Backend Instructor",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Instructor
                {
                    Id = 2,
                    FullName = "Sara Mohamed",
                    Email = "sara@example.com",
                    Specialization = "Angular",
                    Bio = "Angular Instructor",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                }
                ,
                new Instructor
                {
                    Id = 3,
                    FullName = "Omar Hassan",
                    Email = "omar.instructor@example.com",
                    Specialization = "SQL Server",
                    Bio = "Database Instructor",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 9, 1),
                    IsDeleted = false
                },
new Instructor
{
    Id = 4,
    FullName = "Mariam Ali",
    Email = "mariam.instructor@example.com",
    Specialization = "C#",
    Bio = "C# Instructor",
    IsActive = true,
    CreatedAt = new DateTime(2026, 9, 1),
    IsDeleted = false
},
new Instructor
{
    Id = 5,
    FullName = "Khaled Mostafa",
    Email = "khaled.instructor@example.com",
    Specialization = "Software Engineering",
    Bio = "Software Engineering Instructor",
    IsActive = true,
    CreatedAt = new DateTime(2026, 9, 1),
    IsDeleted = false
},
new Instructor
{
    Id = 6,
    FullName = "Nour Ahmed",
    Email = "nour.instructor@example.com",
    Specialization = "Web Development",
    Bio = "Web Development Instructor",
    IsActive = true,
    CreatedAt = new DateTime(2026, 9, 1),
    IsDeleted = false
},
new Instructor
{
    Id = 7,
    FullName = "Yara Mohamed",
    Email = "yara.instructor@example.com",
    Specialization = "APIs",
    Bio = "ASP.NET Core API Instructor",
    IsActive = true,
    CreatedAt = new DateTime(2026, 9, 1),
    IsDeleted = false
}
            );

            // Training Tracks
            modelBuilder.Entity<TrainingTrack>().HasData(
                new TrainingTrack
                {
                    Id = 1,
                    Title = "ASP.NET Core Backend",
                    Code = "DOTNET-BACKEND",
                    Description = "Backend development using ASP.NET Core",
                    Level = TrackLevel.Intermediate,
                    Capacity = 30,
                    StartDate = new DateTime(2026, 10, 1),
                    EndDate = new DateTime(2027, 1, 1),
                    Status = TrainingStatus.Upcoming,
                    InstructorId = 1,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new TrainingTrack
                {
                    Id = 2,
                    Title = "Angular Frontend",
                    Code = "ANGULAR-FE",
                    Description = "Frontend development using Angular",
                    Level = TrackLevel.Intermediate,
                    Capacity = 25,
                    StartDate = new DateTime(2026, 10, 15),
                    EndDate = new DateTime(2027, 1, 15),
                    Status = TrainingStatus.Upcoming,
                    InstructorId = 2,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new TrainingTrack
                {
                    Id = 3,
                    Title = "SQL Server Fundamentals",
                    Code = "SQL-FUNDAMENTALS",
                    Description = "Database development using SQL Server",
                    Level = TrackLevel.Beginner,
                    Capacity = 30,
                    StartDate = new DateTime(2026, 11, 1),
                    EndDate = new DateTime(2027, 1, 1),
                    Status = TrainingStatus.Upcoming,
                    InstructorId = 3,
                    CreatedAt = new DateTime(2026, 9, 1),
                    IsDeleted = false
                },
new TrainingTrack
{
    Id = 4,
    Title = "Advanced C#",
    Code = "CSHARP-ADVANCED",
    Description = "Advanced C# programming concepts",
    Level = TrackLevel.Advanced,
    Capacity = 20,
    StartDate = new DateTime(2026, 11, 10),
    EndDate = new DateTime(2027, 1, 10),
    Status = TrainingStatus.Upcoming,
    InstructorId = 4,
    CreatedAt = new DateTime(2026, 9, 1),
    IsDeleted = false
},
new TrainingTrack
{
    Id = 5,
    Title = "Software Engineering",
    Code = "SOFTWARE-ENG",
    Description = "Software engineering principles and practices",
    Level = TrackLevel.Intermediate,
    Capacity = 25,
    StartDate = new DateTime(2026, 12, 1),
    EndDate = new DateTime(2027, 2, 1),
    Status = TrainingStatus.Upcoming,
    InstructorId = 5,
    CreatedAt = new DateTime(2026, 9, 1),
    IsDeleted = false
},
new TrainingTrack
{
    Id = 6,
    Title = "Web Development",
    Code = "WEB-DEVELOPMENT",
    Description = "Modern web development fundamentals",
    Level = TrackLevel.Beginner,
    Capacity = 35,
    StartDate = new DateTime(2026, 12, 10),
    EndDate = new DateTime(2027, 2, 10),
    Status = TrainingStatus.Upcoming,
    InstructorId = 6,
    CreatedAt = new DateTime(2026, 9, 1),
    IsDeleted = false
},
new TrainingTrack
{
    Id = 7,
    Title = "ASP.NET Core APIs",
    Code = "ASP-NET-APIS",
    Description = "Building RESTful APIs using ASP.NET Core",
    Level = TrackLevel.Advanced,
    Capacity = 25,
    StartDate = new DateTime(2027, 1, 1),
    EndDate = new DateTime(2027, 3, 1),
    Status = TrainingStatus.Upcoming,
    InstructorId = 7,
    CreatedAt = new DateTime(2026, 9, 1),
    IsDeleted = false
}
            );

            // Enrollments
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment
                {
                    Id = 1,
                    StudentId = 1,
                    TrainingTrackId = 1,
                    EnrollmentDate = new DateTime(2026, 9, 10),
                    Status = EnrollmentStatus.Active,
                    ProgressPercentage = 25,
                    FinalResult = null,
                    CreatedAt = DateTime.UtcNow
                },
                new Enrollment
                {
                    Id = 2,
                    StudentId = 2,
                    TrainingTrackId = 1,
                    EnrollmentDate = new DateTime(2026, 9, 11),
                    Status = EnrollmentStatus.Active,
                    ProgressPercentage = 10,
                    FinalResult = null,
                    CreatedAt = DateTime.UtcNow
                }
                ,
                new Enrollment
                {
                    Id = 3,
                    StudentId = 3,
                    TrainingTrackId = 2,
                    EnrollmentDate = new DateTime(2026, 9, 12),
                    Status = EnrollmentStatus.Active,
                    ProgressPercentage = 15,
                    FinalResult = null,
                    CreatedAt = new DateTime(2026, 9, 12)
                },
new Enrollment
{
    Id = 4,
    StudentId = 4,
    TrainingTrackId = 3,
    EnrollmentDate = new DateTime(2026, 9, 13),
    Status = EnrollmentStatus.Active,
    ProgressPercentage = 5,
    FinalResult = null,
    CreatedAt = new DateTime(2026, 9, 13)
},
new Enrollment
{
    Id = 5,
    StudentId = 5,
    TrainingTrackId = 4,
    EnrollmentDate = new DateTime(2026, 9, 13),
    Status = EnrollmentStatus.Active,
    ProgressPercentage = 0,
    FinalResult = null,
    CreatedAt = new DateTime(2026, 9, 13)
},
new Enrollment
{
    Id = 6,
    StudentId = 6,
    TrainingTrackId = 5,
    EnrollmentDate = new DateTime(2026, 9, 13),
    Status = EnrollmentStatus.Active,
    ProgressPercentage = 10,
    FinalResult = null,
    CreatedAt = new DateTime(2026, 9, 13)
},
new Enrollment
{
    Id = 7,
    StudentId = 7,
    TrainingTrackId = 6,
    EnrollmentDate = new DateTime(2026, 9, 13),
    Status = EnrollmentStatus.Active,
    ProgressPercentage = 20,
    FinalResult = null,
    CreatedAt = new DateTime(2026, 9, 13)
}
            );

            // Payments
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = 1,
                    EnrollId = 1,
                    ReferenceNumber = Guid.Parse(
                        "11111111-1111-1111-1111-111111111111"),
                    Amount = 5000,
                    PaymentMethod = PaymentMethod.Cash,
                    PaymentDate = new DateTime(2026, 9, 10),
                    Status = PaymentStatus.Paid,
                    Notes = "First payment"
                },
                new Payment
                {
                    Id = 2,
                    EnrollId = 1,
                    ReferenceNumber = Guid.Parse(
                        "22222222-2222-2222-2222-222222222222"),
                    Amount = 3000,
                    PaymentMethod = PaymentMethod.Visa,
                    PaymentDate = new DateTime(2026, 9, 12),
                    Status = PaymentStatus.Paid,
                    Notes = "Second payment"
                },
                new Payment
                {
                    Id = 3,
                    EnrollId = 2,
                    ReferenceNumber = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Amount = 4000,
                    PaymentMethod = PaymentMethod.BankTransfer,
                    PaymentDate = new DateTime(2026, 9, 11),
                    Status = PaymentStatus.Paid,
                    Notes = "First payment"
                },
new Payment
{
    Id = 4,
    EnrollId = 3,
    ReferenceNumber = Guid.Parse("44444444-4444-4444-4444-444444444444"),
    Amount = 2500,
    PaymentMethod = PaymentMethod.InstaPay,
    PaymentDate = new DateTime(2026, 9, 12),
    Status = PaymentStatus.Paid,
    Notes = "First payment"
},
new Payment
{
    Id = 5,
    EnrollId = 4,
    ReferenceNumber = Guid.Parse("55555555-5555-5555-5555-555555555555"),
    Amount = 3000,
    PaymentMethod = PaymentMethod.Visa,
    PaymentDate = new DateTime(2026, 9, 13),
    Status = PaymentStatus.Paid,
    Notes = "First payment"
},
new Payment
{
    Id = 6,
    EnrollId = 5,
    ReferenceNumber = Guid.Parse("66666666-6666-6666-6666-666666666666"),
    Amount = 2000,
    PaymentMethod = PaymentMethod.Cash,
    PaymentDate = new DateTime(2026, 9, 13),
    Status = PaymentStatus.Pending,
    Notes = "Payment pending"
},
new Payment
{
    Id = 7,
    EnrollId = 6,
    ReferenceNumber = Guid.Parse("77777777-7777-7777-7777-777777777777"),
    Amount = 3500,
    PaymentMethod = PaymentMethod.Mastercard,
    PaymentDate = new DateTime(2026, 9, 13),
    Status = PaymentStatus.Paid,
    Notes = "First payment"
}
            );
        }
    }
}

