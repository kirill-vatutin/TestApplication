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

            builder.HasData(
                 Category.Create(Guid.NewGuid(),"Фрукты", "Свежие фрукты всех видов").Value,
                 Category.Create(Guid.NewGuid(), "Овощи", "Разнообразные овощи для вашего стола").Value,
                 Category.Create(Guid.NewGuid(), "Молочные продукты", "Молоко, сыр, йогурты и другие молочные изделия").Value,
                 Category.Create(Guid.NewGuid(), "Мясные изделия", "Свежие мясные продукты: говядина, свинина, птица").Value,
                 Category.Create(Guid.NewGuid(), "Замороженные продукты", "Замороженные овощи, фрукты и готовые блюда").Value,
                 Category.Create(Guid.NewGuid(), "Кондитерские изделия", "Шоколад, печенье, торты и сладости").Value,
                 Category.Create(Guid.NewGuid(), "Напитки", "Безалкогольные и алкогольные напитки различных брендов").Value,
                 Category.Create(Guid.NewGuid(), "Бакалея", "Крупы, макароны, консервированные продукты").Value,
                 Category.Create(Guid.NewGuid(), "Здоровое питание", "Продукты для вегетарианцев и людей с особыми диетами").Value,
                 Category.Create(Guid.NewGuid(), "Хозяйственные товары", "Товары для дома: моющие средства, упаковка и прочее").Value
 );



        }
    }
}
