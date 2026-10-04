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
    public class TrainingTrackConfiguration : IEntityTypeConfiguration<TrainingTrack>
    {
        public void Configure(EntityTypeBuilder<TrainingTrack> builder)
        {
            builder.Property(t => t.Title).HasMaxLength(100).IsRequired();

            builder.Property(t => t.Code).HasMaxLength(100).IsRequired();

            builder.HasIndex(t => t.Code).IsUnique();

            builder.Property(t => t.Description).HasMaxLength(100);

            builder.Property(t => t.Status).HasConversion<string>();

            builder.Property(t => t.Capacity).IsRequired();

            builder.Property(t => t.Level).HasConversion<string>().IsRequired();


            builder.HasOne(t => t.Instructor)
                   .WithMany(i => i.TrainingTracks)
                   .HasForeignKey(t => t.InstructorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
