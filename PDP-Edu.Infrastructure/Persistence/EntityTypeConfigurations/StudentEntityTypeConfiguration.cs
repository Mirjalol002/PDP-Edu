using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDP_Edu.Domain.Entities;

namespace PDP_Edu.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
