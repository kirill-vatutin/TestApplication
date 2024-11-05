using CSharpFunctionalExtensions;
using Items.CreateItem;
using Microsoft.EntityFrameworkCore;
using TestApplication.Application.IRepositories;
using TestApplication.Application.Response;
using TestApplication.Domain.Models.Entities;
using TestApplication.Domain.Models.ValueObjects;
using TestApplication.Domain.Shared;

namespace TestApplication.Infrastructure.Repositories;

public class ItemRepository(ApplicationDbContext context) : IItemRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<Item>> GetById(Guid id, CancellationToken ct = default)
    {
        var item = await _context.Items
                    .Include(i => i.Category)
                    .FirstOrDefaultAsync(i => i.Id == id, cancellationToken: ct);
        if (item is null) return Result.Failure<Item>($"Not found {id}");
        return item;
    }

    public async Task<Result<Item, Error>> GetById(ItemId itemId)
    {
        var item = await _context.Items
            .FirstOrDefaultAsync(i => i.Id == itemId);

        if (item is null)
        {
            return Errors.General.NotFound(itemId);
        }

        return item;
    }

    public async Task<Guid> Delete(Item item, CancellationToken cancellationToken)
    {
        _context.Items.Remove(item);
        await _context.SaveChangesAsync(cancellationToken);

        return item.Id;
    }

    public async Task<Guid> Add(Item item, CancellationToken cancellationToken)
    {
        await _context.Items.AddAsync(item, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return item.Id;
    }

    public async Task<Guid> SaveAsync(Item item, CancellationToken cancellationToken)
    {
        _context.Items.Attach(item);
        await _context.SaveChangesAsync(cancellationToken);

        return item.Id.Value;
    }

    public async Task<IReadOnlyList<ItemResponse>> GetAll(CancellationToken cancellationToken)
    {
        var itemsResponse = await _context.Items
            .AsNoTracking()
            .Include(i => i.Category)
            .Select(
                item =>
                    new ItemResponse(
                        item.Id,
                        item.Name,
                        item.Description,
                        item.Price,
                        item.Count,
                        item.Category!.Name,
                        item.CreatedTime,
                        item.UpdatedTime
                        )
                ).ToListAsync(cancellationToken);

        return itemsResponse;
    }
}
