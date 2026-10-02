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
    public class TrackSessionConfiguration : IEntityTypeConfiguration<TrackSession>
    {
        public void Configure(EntityTypeBuilder<TrackSession> builder)
        {
            builder.Property(t => t.Title).HasColumnType("varchar(50)").IsRequired();

            builder.Property(t => t.Description).HasMaxLength(100).IsRequired();

            builder.HasOne(s => s.TrainingTrack)
                   .WithMany(t => t.TrackSessions)
                   .HasForeignKey(s => s.TrackId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

            builder.HasOne(s => s.CreatedByInstructor)
                   .WithMany(i => i.TrackSessions)
                   .HasForeignKey(s => s.CreatedByInstructorId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();


        }
    }
}
