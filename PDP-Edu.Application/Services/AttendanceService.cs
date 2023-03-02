using Microsoft.EntityFrameworkCore;
using PDP_Edu.Application.Abstractions;
using PDP_Edu.Application.Models;
using PDP_Edu.Domain.Entities;


namespace PDP_Edu.Application.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public AttendanceService(IApplicationDbContext context, ICurrentUserService current)
        {
            _context = context;
            _currentUserService = current;
        }
        public async Task CheckAsync(DoAttendanceCheckModel model)
        {
            var lesson = await _context.Lessons.Include(x => x.Group).FirstOrDefaultAsync(x => x.Id == model.LessonId);

            if (lesson == null || lesson.Group.TeacherId != _currentUserService.UserId)
            {
                throw new Exception("Not found");
            }

            var groupStudents = await _context.Lessons
                               .Where(x => x.Id == model.LessonId)
                               .Include(x => x.Group)
                               .ThenInclude(x => x.StudentGroups)
                               .SelectMany(x => x.Group.StudentGroups)
                               .Select(x => x.StudentId)
                               .ToListAsync();

            var attandenceList = new List<Attendance>();

            foreach (var group in groupStudents)
            {
                var check = model.Checks.FirstOrDefault(x => x.StudentId == group);

                var attendance = new Attendance()
                {
                    StudentId = group,
                    LessonId = model.LessonId,
                    HasParticipated = false
                };
                if (check != null)
                {
                    attendance.HasParticipated = check.HasParticipated;
                }
                attandenceList.Add(attendance);
            }

            _context.Attendances.AddRange(attandenceList);
            await _context.SaveChangesAsync();
        }

    }
}
