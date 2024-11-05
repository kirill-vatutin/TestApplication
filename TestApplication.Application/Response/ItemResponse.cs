namespace TestApplication.Application.Response;

public record ItemResponse(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    int Count,
    string CategoryName,
    DateTime CreatedTime,
    DateTime? UpdatedTime
);
