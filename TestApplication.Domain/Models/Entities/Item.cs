using TestApplication.Domain.Models.ValueObjects;
using TestApplication.Domain.Shared;

namespace TestApplication.Domain.Models.Entities;

public class Item : Entity<ItemId>, ITimeEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    public decimal Price { get; private set; }
    public int Count { get; private set; }

    public Guid CategoryId { get; private set; }
    public Category? Category { get; private set; }

    public DateTime CreatedTime { get; private set; }
    public DateTime? UpdatedTime { get; private set; }

    public void UpdateMainInfo(
        string name,
        string description,
        decimal price,
        int count)
    {
        Name = name;
        Description = description;
        Price = price;
        Count = count;
    }

    public void UpdateCreatedTime()
    {
        CreatedTime = DateTime.UtcNow;
    }

    public void UpdateUpdatedTime()
    {
        UpdatedTime = DateTime.UtcNow;
    }

    //EF Core
    private Item(ItemId id) : base(id) { }
    public Item(
        ItemId id,
        string name,
        string description,
        decimal price,
        int count,
        Guid categoryId) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        Count = count;
        CategoryId = categoryId;
        UpdatedTime = null;
    }
}
