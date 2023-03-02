using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PDP_Edu.Application.Abstractions;

namespace PDP_Edu.Application.Services
{
    public class LessonStatusCheckService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public LessonStatusCheckService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var period = new PeriodicTimer(TimeSpan.FromSeconds(10));
            while (await period.WaitForNextTickAsync(stoppingToken))
            {
                using var scope = _serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

                var lessons = await context.Lessons
                    .Include(x => x.Attendances)
                    .Where(x =>
                        x.EndDateTime.Date == DateTime.Now.Date &&
                        x.EndDateTime < DateTime.Now)
                    .ToListAsync(stoppingToken);

                foreach (var lesson in lessons)
                {
                    lesson.isDone = lesson.Attendances.Any();
                    context.Lessons.Update(lesson);
                }
                await context.SaveChangesAsync(stoppingToken);
            }
        }
    }
}