using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingCenter.DAL.Persistent.Dataseeding;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;

namespace TrainingCenter.DAL.Persistent
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity<int>>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }

                else {

                    entry.Entity.DeletedAt = DateTime.UtcNow;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Assembly).Assembly);
            Seeding.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<Student> Students {  get; set; }

        public virtual DbSet<Instructor> Instructors { get; set; }

        public virtual DbSet<Enrollment>  Enrollmets { get; set; }

        public virtual DbSet<TrainingTrack> TrainingTracks { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }


    }

}
