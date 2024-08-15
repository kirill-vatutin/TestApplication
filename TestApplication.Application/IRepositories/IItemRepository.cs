using CSharpFunctionalExtensions;
using TestApplication.Application.DTO;
using TestApplication.Domain.Models;

namespace TestApplication.Infrastructure.Repositories
{
    public interface IItemRepository
    {

        Task<Result<Item>> Save(CreateItemRequest request, CancellationToken ct);
        Task<IEnumerable<ItemResponse>> Get(CancellationToken ct);
        Task<IEnumerable<ItemResponse>> GetByCategory(Guid categoryId, CancellationToken ct);
        Task<Result<Item>> GetById(Guid id, CancellationToken ct);
        
    }
}