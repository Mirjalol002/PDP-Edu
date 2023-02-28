using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDP_Edu.Domain.Entities;

namespace PDP_Edu.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class StudentGroupEntityTypeConfiguration : IEntityTypeConfiguration<StudentGroup>
    {
        public void Configure(EntityTypeBuilder<StudentGroup> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Student)
                .WithMany(x => x.StudentGroups)
                .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.Group)
                .WithMany(x => x.StudentGroups)
                .HasForeignKey(x => x.GroupId);
        }
    }
}
