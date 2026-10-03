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
    public class ActivityLogConfiguration : IEntityTypeConfiguration<ActivityLog>
    {
        public void Configure(EntityTypeBuilder<ActivityLog> builder)
        {

            builder.Property(x => x.UserId)
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(x => x.UserRole)
                .HasMaxLength(50)
                 .IsRequired();
                

            builder.Property(x => x.Action)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.EntityName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.EntityId)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.IpAddress)
                .HasMaxLength(45);

            builder.Property(x => x.Metadata)
                .HasColumnType("nvarchar(max)");
        }
    }
}
