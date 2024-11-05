using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApplication.Domain.Models.Entities;
using TestApplication.Domain.Models.ValueObjects;
using TestApplication.Domain.Shared;

namespace TestApplication.Infrastructure.Configuration;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("items");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .HasConversion(
            id => id.Value,
            value => ItemId.Create(value)
            );

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
