using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using TestApplication.Application.DTO;
using TestApplication.Domain.Models;
using TestApplication.Infrastucture;


namespace TestApplication.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Item>> Save(CreateItemRequest request, CancellationToken ct = default)
        {
            var result =  Item.Create(Guid.NewGuid()
                                  , request.Name
                                  , request.Description
                                  , request.Price
                                  , request.Count
                                  , request.CategoryId);
            if (result.IsFailure) return result;
            var item = result.Value;
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<ItemResponse>> Get(CancellationToken ct)
        {
            var items = await _context.Items.AsNoTracking()
                .Include(i=>i.Category)
                .ToListAsync();
            return items.Select(i => new ItemResponse
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
                Price = i.Price,
                Count = i.Count,
                Category = i.Category.Name
            });
            

        }

        public async Task<Result<Item>> GetById(Guid id, CancellationToken ct)
        {
            var item = await _context.Items
                        .AsNoTracking()
                        .Include(i => i.Category)
                        .FirstOrDefaultAsync(i => i.Id == id, cancellationToken: ct);
            if (item is null) return Result.Failure<Item>($"Not found {id}");
            return item;
        }

        public async Task<IEnumerable<ItemResponse>> GetByCategory(Guid categoryId, CancellationToken ct)
        {
            IQueryable<Item> itemsQuery = _context.Items;
            var items = await itemsQuery
                .AsNoTracking()
                .Where(i => i.CategoryId == categoryId)
                .Include(i => i.Category)
                .ToListAsync();
            return items.Select(i => new ItemResponse
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
                Price = i.Price,
                Count = i.Count,
                Category = i.Category.Name
            });
        }
    }
}
