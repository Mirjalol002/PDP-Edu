using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDP_Edu.Domain.Entities;

namespace PDP_Edu.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class LessonEntityTypeConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Group)
                .WithMany(e => e.Lessons)
                .HasForeignKey(e => e.GroupId);


        }
    }
}
