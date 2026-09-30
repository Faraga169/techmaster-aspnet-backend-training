using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.DAL.Persistent.Configurations
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.Property(e => e.ProgressPercentage).HasPrecision(5, 2).IsRequired();
            builder.Property(e => e.Status).HasConversion<string>().IsRequired();

            builder.HasIndex(e => new { e.StudentId, e.TrainingTrackId }).IsUnique();

            builder.HasOne(e => e.Student)
                   .WithMany(s => s.Enrollments)
                   .HasForeignKey(e => e.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.TrainingTrack)
                  .WithMany(s => s.Enrollments)
                  .HasForeignKey(e => e.TrainingTrackId)
                  .OnDelete(DeleteBehavior.Restrict);

           
        }
    }
}
