using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using static TestApplication.Domain.Shared.Errors;
using TestApplication.Domain.Shared;
using Items.CreateItem;
using TestApplication.Domain.Models.ValueObjects;
using TestApplication.Domain.Models.Entities;
using TestApplication.Application.IRepositories;

namespace TestApplication.Application.Items.CreateItem;

public class CreateItemHandler(
    IItemRepository repository,
    ILogger<CreateItemHandler> logger)
{
    public async Task<Result<Guid, Error>> Handle(
        CreateItemRequest request, CancellationToken cancellationToken = default)
    {

        var itemId = ItemId.NewItemId();

        var existItem = await repository.GetById(itemId, cancellationToken);

        if (existItem.IsSuccess)
        {
            Errors.Item.AlreadyExist();
        }

        var item = new Domain.Models.Entities.Item(
            itemId,
            request.Name,
            request.Description,
            request.Price,
            request.Count,
            request.CategoryId);

        await repository.Add(item, cancellationToken);

        logger.LogInformation("Created item {name} with Id:{itemId}", item.Name, item.Id);

        return (Guid)item.Id;
    }
}

