using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApplication.Domain.Models;
using TestApplication.Domain.Shared;

namespace TestApplication.Infrastucture.Configuration
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("items");

            builder.HasKey(x => x.Id);

            builder.Property(i => i.Name)
                .IsRequired(true)
                .HasMaxLength(Constants.MAX_LOW_LENGTH);

            builder.Property(i => i.Description)
                .IsRequired(true)
                .HasMaxLength(Constants.MAX_LONG_LENGTH);

            builder.Property(i => i.Price)
                .IsRequired(true);

            builder.Property(i => i.Count)
                .IsRequired(true);

            builder.Property(i => i.CreatedTime)
                .IsRequired(true);

            builder.Property(i => i.UpdatedTime)
                .IsRequired(false);

            builder.HasOne(i => i.Category)
                    .WithMany(c => c.Items)
                    .HasForeignKey(i => i.CategoryId)
                    .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
