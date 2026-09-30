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
    public class InstructorConfigurations : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.Property(i => i.FullName).HasColumnType("varchar(50)").IsRequired();

            builder.Property(i => i.Email).HasColumnType("varchar(100)").IsRequired();
            builder.HasIndex(i => i.Email).IsUnique();

            builder.Property(i => i.IsActive).HasColumnType("bit");

            builder.Property(i => i.Specialization).HasColumnType("varchar(50)").IsRequired();

            builder.Property(i => i.Bio).HasColumnType("varchar(500)");
        }
    }
}
