using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDP_Edu.Domain.Entities;

namespace PDP_Edu.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class GroupEntityTypeConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(x => x.Teacher)
                .WithMany(x => x.Groups)
                .HasForeignKey(x => x.TeacherId);

        }
    }
}
