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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(p => p.Amount).HasPrecision(18, 2).IsRequired();

            builder.Property(p => p.PaymentMethod).HasConversion<string>().IsRequired();

            builder.Property(p => p.Status).HasConversion<string>().IsRequired();

            builder.Property(p => p.Notes).HasMaxLength(100);


            builder.HasOne(p => p.Enrollment)
                   .WithMany(e => e.Payments)
                   .HasForeignKey(p => p.EnrollId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
