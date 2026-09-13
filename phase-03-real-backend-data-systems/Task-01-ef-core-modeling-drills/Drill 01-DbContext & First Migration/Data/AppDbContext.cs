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


            modelBuilder.Entity<Enrollment>()
                        .HasOne(e => e.Student)
                        .WithMany(s=>s.Enrollments)
                        .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>().Property(e => e.Status).HasConversion<string>();

            modelBuilder.Entity<Enrollment>().HasIndex(e => new { e.StudentId, e.TrackId }).IsUnique().HasFilter("[Status] = 'Active'");

            modelBuilder.Entity<Enrollment>()
                       .HasOne(e => e.Track)
                       .WithMany(s => s.Enrollments)
                       .HasForeignKey(e => e.TrackId);

            modelBuilder.Entity<PaymentSummary>()
                        .HasOne(p => p.Enrollment)
                        .WithOne(e => e.PaymentSummary)
                        .HasForeignKey<PaymentSummary>(p => p.EnrollmentId);

            modelBuilder.Entity<PaymentSummary>().HasIndex(p => p.EnrollmentId).IsUnique();


            modelBuilder.Entity<PaymentSummary>().Property(p => p.PaymentStatus).HasConversion<string>();

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

            modelBuilder.Entity<Enrollment>().HasData(
    new Enrollment
    {
        Id = 1,
        StudentId = 1,
        TrackId = 1,
        Status = Status.Active,
        EnrollmentDate = new DateTime(2026, 9, 1),
        FinalGrade = 92.5m
    },
    new Enrollment
    {
        Id = 2,
        StudentId = 1,
        TrackId = 2,
        Status = Status.Pending,
        EnrollmentDate = new DateTime(2026, 9, 2),
        FinalGrade = 0m
    },
    new Enrollment
    {
        Id = 3,
        StudentId = 2,
        TrackId = 1,
        Status = Status.Completed,
        EnrollmentDate = new DateTime(2026, 8, 20),
        FinalGrade = 88.0m
    },
    new Enrollment
    {
        Id = 4,
        StudentId = 2,
        TrackId = 3,
        Status = Status.Active,
        EnrollmentDate = new DateTime(2026, 9, 3),
        FinalGrade = 85.5m
    },
    new Enrollment
    {
        Id = 5,
        StudentId = 3,
        TrackId = 3,
        Status = Status.Completed,
        EnrollmentDate = new DateTime(2026, 8, 25),
        FinalGrade = 95.0m,

    }

    );
    modelBuilder.Entity<PaymentSummary>().HasData(
    new PaymentSummary
    {
        Id = 1,
        EnrollmentId = 1,
        TotalRequired = 10000m,
        TotalPaid = 10000m,
        PaymentStatus = PaymentStatus.Paid,
     
    },
    new PaymentSummary
    {
        Id = 2,
        EnrollmentId = 2,
        TotalRequired = 12000m,
        TotalPaid = 4000m,
        PaymentStatus = PaymentStatus.PartiallyPaid
    },
    new PaymentSummary
    {
        Id = 3,
        EnrollmentId = 3,
        TotalRequired = 10000m,
        TotalPaid = 0m,
        PaymentStatus = PaymentStatus.Pending
    },
    new PaymentSummary
    {
        Id = 4,
        EnrollmentId = 4,
        TotalRequired = 15000m,
        TotalPaid = 7500m,
        PaymentStatus = PaymentStatus.PartiallyPaid
    },
    new PaymentSummary
    {
        Id = 5,
        EnrollmentId = 5,
        TotalRequired = 15000m,
        TotalPaid = 15000m,
        PaymentStatus = PaymentStatus.Paid
    }

);

        }

        public virtual DbSet<Student> Students { set; get; }

        public virtual DbSet<StudentProfile> StudentsProfile { get; set; }

        public virtual DbSet<Instructor> Instructors { get; set; }

        public virtual DbSet<TrainingTrack> Tracks { get; set; }


        public virtual DbSet<Enrollment> Enrollments { get; set; }

        public virtual DbSet<PaymentSummary> PaymentSummaries { get; set; }
    }
}
