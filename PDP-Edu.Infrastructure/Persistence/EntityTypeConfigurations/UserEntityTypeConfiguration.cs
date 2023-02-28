using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDP_Edu.Domain.Entities;
using PDP_Edu.Domain.Enums;

namespace PDP_Edu.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                .HasMaxLength(128)
                .IsRequired();

            builder.HasIndex(x => x.UserName).IsUnique();

            builder.HasData(new User
            {
                Id = 1,
                UserName = "Admin",
                PasswordHash =
                    "CA5B9811BE39C13BA3F8265C006761214B85F36FFE177C482AA548A30FC2C8994F5AE33790A4AE6A302B65A05A906AAED4912F02C0E69FC6CE14A9C90AD998A0",
                Role = UserRole.Admin,
                FullName = "Adminbek Adminov"
            });

        }
    }
}
