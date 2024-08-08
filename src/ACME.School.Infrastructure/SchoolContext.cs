using ACME.School.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ACME.School.Infrastructure
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
              .HasKey(c => c.Id);

                    modelBuilder.Entity<Student>()
                        .HasKey(s => s.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
