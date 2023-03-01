using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PDP_Edu.Application.Abstractions;
using PDP_Edu.Infrastructure.Abstractions;
using PDP_Edu.Infrastructure.Persistance;
using PDP_Edu.Infrastructure.Providers;
using PDP_Edu.Infrastructure.Services;
using PDP_Edu.Domain.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace PDP_Edu.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ITokenService, JWTService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddSingleton<IHashProvider, HashProvider>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!))
                };
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminActions", policy =>
                {
                    policy.RequireClaim("Role", UserRole.Admin.ToString());
                });
            });

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }
    }
}