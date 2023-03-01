using Microsoft.EntityFrameworkCore;
using PDP_Edu.Application.Abstractions;
using PDP_Edu.Domain.Entities;
using PDP_Edu.Infrastructure.Persistence.EntityTypeConfigurations;

namespace PDP_Edu.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<StudentGroup> StudentsGroups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StudentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GroupEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StudentGroupEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LessonEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AttendanceEntityTypeConfiguration());
        }
    }
}
