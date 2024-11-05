namespace TestApplication.Domain.Models.ValueObjects;

public record ItemId
{
    public Guid Value { get; }

    public ItemId(Guid value)
    {
        Value = value;
    }

    public static ItemId NewItemId() => new(Guid.NewGuid());
    public static ItemId Empty() => new(Guid.Empty);
    public static ItemId Create(Guid id) => new(id);

    public static implicit operator Guid(ItemId id) => id.Value;
}
