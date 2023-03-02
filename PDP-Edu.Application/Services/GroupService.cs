using Microsoft.EntityFrameworkCore;
using PDP_Edu.Application.Abstractions;
using PDP_Edu.Application.Models;
using PDP_Edu.Application.Models.Group;
using PDP_Edu.Domain.Entities;

namespace PDP_Edu.Application.Services
{
    public class GroupService : IGroupService
    {
        private readonly IApplicationDbContext _context;
        public GroupService(IApplicationDbContext context)
        {
            _context = context;
        }

        // 1 
        public async Task<GroupViewModel> GetByIdAsync(int id)
        {
            var entity = await _context.Groups.FirstOrDefaultAsync(x => x.Id == id);
            return new GroupViewModel()
            {
                Id = entity!.Id,
                Name = entity.Name,
                TeacherId = entity.TeacherId,
                StartedDate = entity.StartDate,
                EndDate = entity.EndDate
            };
        }

        // 2 
        public async Task<List<GroupViewModel>> GetAllAsync()
        {
            return await _context.Groups
                                .Select(x => new GroupViewModel()
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                    TeacherId = x.TeacherId,
                                    StartedDate = x.StartDate,
                                    EndDate = x.EndDate,
                                }).ToListAsync();
        }

        // 3
        public async Task CreateAsync(CreateGroupModel entity)
        {
            var entities = new Group()
            {
                Name = entity.Name,
                TeacherId = entity.TeacherId,
                StartDate = entity.StartedDate.ToDateTime(TimeOnly.MinValue),
                EndDate = entity.EndDate.ToDateTime(TimeOnly.MaxValue),
            };
            _context.Groups.Add(entities);
            var lessons = CreateLessons(entities, entity.LessonStartTime, entity.LessonEndTime);
            _context.Lessons.AddRange(lessons);
            await _context.SaveChangesAsync();
        }

        // 4
        public async Task UpdateAsync(UpdateGroupModel entity)
        {
            var entities = await _context.Groups.Include(x => x.Lessons).FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (entities == null)
            {
                throw new Exception("Not found");
            }

            entities.Name = entity.Name ?? entities.Name;
            entities.TeacherId = entity.TeacherId ?? entities.TeacherId;

            _context.Groups.Update(entities);
            await _context.SaveChangesAsync();
        }

        // 5
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Groups.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new Exception("Not found");
            }
            _context.Groups.Remove(entity);
            await _context.SaveChangesAsync();
        }

        // 6
        public async Task<List<LessonViewModel>> GetLessonAsync(int groupId)
        {
            return await _context.Lessons.Where(x => x.GroupId == groupId).Select(x => new LessonViewModel()
            {
                Id = x.Id,
                GroupId = x.GroupId,
                StartDateTime = x.StartedDateTime,
                EndDateTime = x.EndDateTime
            }).ToListAsync();
        }

        // 7
        public async Task AddStudentAsync(AddStudentGroupModel model, int groupId)
        {
            if (!await _context.Students.AnyAsync(x => x.Id == model.StudentId))
            {
                throw new Exception("Not found");
            }
            if (!await _context.Groups.AnyAsync(x => x.Id == groupId))
            {
                throw new Exception("Not found");
            }

            var studentGroup = new StudentGroup()
            {
                GroupId = groupId,
                StudentId = model.StudentId,
                IsPaid = model.IsPaid,
                JoinedDate = model.JoinedDate,
            };
            await _context.StudentsGroups.AddAsync(studentGroup);
            await _context.SaveChangesAsync();
        }


        // 8
        public async Task RemoveStudentAsync(int studentId, int groupId)
        {
            var entity = await _context.StudentsGroups.FirstOrDefaultAsync(x => x.GroupId == groupId && x.StudentId == studentId);
            if (entity != null)
            {
                throw new Exception("Not found");
            }
            _context.StudentsGroups.Remove(entity!);
            await _context.SaveChangesAsync();
        }



        // 9 Qo'shimcha 
        private List<Lesson> CreateLessons(Group entity, TimeSpan lessonStartTime, TimeSpan lessonEndTime)
        {
            var lessons = new List<Lesson>();

            var totalDaysFromStartToEnd = (entity.EndDate - entity.StartDate).Days;

            var currentDate = entity.StartDate;
            for (int i = 1; i <= totalDaysFromStartToEnd; i++)
            {
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var lesson = new Lesson()
                    {
                        Group = entity,
                        StartedDateTime = currentDate.Date + lessonStartTime,
                        EndDateTime = currentDate.Date + lessonEndTime
                    };

                    lessons.Add(lesson);
                }

                currentDate = currentDate.AddDays(1);
            }

            return lessons;
        }
    }
}