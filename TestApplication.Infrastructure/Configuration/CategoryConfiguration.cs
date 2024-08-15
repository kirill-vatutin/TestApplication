using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApplication.Domain.Models;
using TestApplication.Domain.Shared;

namespace TestApplication.Infrastucture.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category");

            builder.HasKey(x => x.Id);

            builder.Property(i => i.Name)
                .IsRequired(true)
                .HasMaxLength(Constants.MAX_LOW_LENGTH);

            builder.Property(i => i.Description)
                .IsRequired(true)
                .HasMaxLength(Constants.MAX_LONG_LENGTH);
          

        }
    }
}
