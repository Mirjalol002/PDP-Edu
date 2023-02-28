using PDP_Edu.Domain.Entities;
using System.Data.Entity;

namespace PDP_Edu.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Domain.Entities.Group> Groups { get; set; }
        DbSet<StudentGroup> StudentsGroups { get; set; }
        DbSet<Lesson> Lessons { get; set; }
        DbSet<Attendance> Attendances { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
