using CSharpFunctionalExtensions;
using TestApplication.Application.Response;
using TestApplication.Domain.Models.Entities;

namespace TestApplication.Application.IRepositories;

public interface IItemRepository
{
    Task<Result<Item>> GetById(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> Delete(Item itemm, CancellationToken cancellationToken = default);
    Task<Guid> Add(Item item, CancellationToken cancellationToken = default);
    Task<Guid> SaveAsync(Item item, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ItemResponse>> GetAll(CancellationToken cancellationToken = default);
}