namespace TestApplication.Application.DTO
{
    public record CreateItemRequest(
         string Name,
         string Description,
         int Price,
         int Count,
         Guid CategoryId
     );

}
