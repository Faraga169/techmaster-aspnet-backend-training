using Drill_01_DbContext___First_Migration.Models;
using Microsoft.EntityFrameworkCore;

namespace Drill_01_DbContext___First_Migration.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentProfile>()
                        .HasOne(sp=>sp.Student)
                        .WithOne(s=>s.StudentProfile)
                        .HasForeignKey<StudentProfile>(sp=>sp.StudentId);

            modelBuilder.Entity<Instructor>()
                        .HasMany(i => i.TrainingTracks)
                        .WithOne(t => t.Instructor)
                        .HasForeignKey(t => t.InstructorId)
                        .IsRequired();





            modelBuilder.Entity<Instructor>().HasData(
    new Instructor
    {
        Id = 1,
        FullName = "Ahmed Hassan",
        Email = "ahmed.hassan@example.com"
    },
    new Instructor
    {
        Id = 2,
        FullName = "Mohamed Ali",
        Email = "mohamed.ali@example.com"
    }
);

            modelBuilder.Entity<TrainingTrack>().HasData(
                new TrainingTrack
                {
                    Id = 1,
                    Name = "ASP.NET Backend",
                    Description = "Backend development using ASP.NET Core",
                    InstructorId = 1
                },
                new TrainingTrack
                {
                    Id = 2,
                    Name = "Angular Frontend",
                    Description = "Frontend development using Angular",
                    InstructorId = 1
                },
                new TrainingTrack
                {
                    Id = 3,
                    Name = "Full Stack .NET",
                    Description = "Full Stack development using .NET and Angular",
                    InstructorId = 2
                }
            );

            modelBuilder.Entity<Student>().HasData(
       new Student
       {
           Id = 1,
           FullName = "Ahmed Farag",
           Email = "ahmed@example.com",
           CreatedAt = new DateTime(2026, 9, 13),
           IsActive = true
       },
       new Student
       {
           Id = 2,
           FullName = "Mohamed Ali",
           Email = "mohamed@example.com",
           CreatedAt = new DateTime(2026, 9, 13),
           IsActive = true
       },
       new Student
       {
           Id = 3,
           FullName = "Amna Ali",
           Email = "amna@example.com",
           CreatedAt = new DateTime(2026, 9, 13),
           IsActive = true
       }
   );

            modelBuilder.Entity<StudentProfile>().HasData(
                new StudentProfile
                {
                    Id=1,
                    StudentId = 1,
                    NationalId = 29801011234567,
                    Address = "Cairo, Egypt",
                    EmergencyPhone = "01012345678",
                    DateOfBirth = new DateTime(1998, 1, 1)
                },
                new StudentProfile
                {
                    Id=2,
                    StudentId = 2,
                    NationalId = 29902021234568,
                    Address = "Giza, Egypt",
                    EmergencyPhone = "01112345678",
                    DateOfBirth = new DateTime(1999, 2, 2)
                },
                new StudentProfile
                {
                    Id = 3,
                    StudentId = 3,
                    NationalId = 30003031234569,
                    Address = "Alexandria, Egypt",
                    EmergencyPhone = "01212345678",
                    DateOfBirth = new DateTime(2000, 3, 3)
                }
            );


        }

        public virtual DbSet<Student> Students { set; get; }

        public virtual DbSet<StudentProfile> StudentsProfile { get; set; }

        public virtual DbSet<Instructor> Instructors { get; set; }

        public virtual DbSet<TrainingTrack> Tracks { get; set; }
    }
}
