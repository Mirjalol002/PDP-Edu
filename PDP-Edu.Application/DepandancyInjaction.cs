using Microsoft.Extensions.DependencyInjection;
using PDP_Edu.Application.MappingProfiles;
using PDP_Edu.Application.Abstractions;
using PDP_Edu.Application.Services;
using AutoMapper;


namespace PDP_Edu.Application
{
    public static class DepandancyInjaction
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile(provider.GetRequiredService<IHashProvider>()));
            }).CreateMapper());
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddHostedService<LessonStatusCheckService>();
            return services;
        }
    }
}
