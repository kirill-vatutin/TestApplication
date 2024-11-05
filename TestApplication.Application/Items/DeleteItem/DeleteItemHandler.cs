using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using TestApplication.Application.IRepositories;
using TestApplication.Domain.Shared;

namespace TestApplication.Application.Items.DeleteItem;

public class DeleteItemHandler(
    ILogger<DeleteItemHandler> logger,
    IItemRepository repository)
{
    public async Task<Result<Guid, Error>> Handle(
        DeleteItemRequest request,
        CancellationToken cancellationToken)
    {
        var existItem = await repository.GetById(request.ItemId, cancellationToken);

        if (existItem.IsFailure)
        {
            return Errors.General.NotFound();
        }

        var item = existItem.Value;

        var id = await repository.Delete(item, cancellationToken);

        logger.LogInformation("Delete item with id:{Id}", id);

        return id;
    }
}
