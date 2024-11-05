namespace Items.CreateItem;

public record CreateItemRequest(
    string Name,
    string Description,
    decimal Price,
    int Count,
    Guid CategoryId
    );
