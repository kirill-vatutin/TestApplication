using Microsoft.Extensions.Logging;
using TestApplication.Application.IRepositories;
using TestApplication.Application.Response;

namespace TestApplication.Application.Items.GetItems;

public class GetItemsHandler(
    ILogger<GetItemsHandler> logger,
    IItemRepository repository)
{
    public async Task<IReadOnlyList<ItemResponse>> Handle(CancellationToken cancellationToken)
    {
        var items = await repository.GetAll(cancellationToken);

        if (items is null) return [];

        logger.LogInformation("Recieved {count} items", items.Count);

        return items;
    }
}
