using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using TestApplication.Application.IRepositories;
using TestApplication.Domain.Shared;

namespace TestApplication.Application.Items.UpdateMainInfo;

public class UpdateMainInfoHandler(
    ILogger<UpdateMainInfoHandler> logger,
    IItemRepository repository)
{
    public async Task<Result<Guid, Error>> Handle(
        UpdateMainInfoRequest request,
        CancellationToken cancellationToken
        )
    {
        var existItem = await repository.GetById(request.Id, cancellationToken);

        if (existItem.IsFailure)
        {
            return Errors.General.NotFound();
        }

        var item = existItem.Value;

        item.UpdateMainInfo(
            request.Dto.Name,
            request.Dto.Description,
            request.Dto.Price,
            request.Dto.Count);

        var result = await repository.SaveAsync(item, cancellationToken);

        logger.LogInformation("Updated item {name} with Id:{itemId}", item.Name, item.Id);

        return result;
    }
}
