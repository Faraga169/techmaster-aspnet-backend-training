using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingCenter.DAL.presistent.Models;

namespace TrainingCenter.DAL.Persistent.Configurations
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.FullName).HasColumnType("varchar(50)").IsRequired();

            builder.Property(s => s.Email).HasColumnType("varchar(100)").IsRequired();
            builder.HasIndex(s => s.Email).IsUnique();

            builder.Property(s => s.IsActive).HasColumnType("bit");

            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }
}
