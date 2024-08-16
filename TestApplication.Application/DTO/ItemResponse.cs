namespace TestApplication.Application.DTO
{
    public record ItemResponse
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public int Count { get; init; }
        public string Category { get; init; } = string.Empty;
    }

}
