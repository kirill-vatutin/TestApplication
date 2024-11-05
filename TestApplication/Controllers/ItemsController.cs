using FluentValidation;
using Items.CreateItem;
using Microsoft.AspNetCore.Mvc;
using TestApplication.API.Extensions;
using TestApplication.API.Response;
using TestApplication.Application.Items.CreateItem;
using TestApplication.Application.Items.DeleteItem;
using TestApplication.Application.Items.GetItems;
using TestApplication.Application.Items.GetItemsExcel;
using TestApplication.Application.Items.UpdateMainInfo;
using TestApplication.Domain.Models.Entities;
using TestApplication.Domain.Shared;
namespace TestApplication.API.Controllers;

public class ItemsController : ApplicationController
{
    [HttpGet("download-excel")]
    public async Task<ActionResult> DownloadExcel(
        [FromServices] GetItemsExcelHandler handler,
        CancellationToken cancellationToken)
    {
        var fileContent = await handler.Handle(cancellationToken);
        if (fileContent is null)
            return NotFound();
        return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyData.xlsx");
    }

    [HttpGet("items")]
    public async Task<ActionResult<IReadOnlyList<Item>>> GetAll(
        [FromServices] GetItemsHandler handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Create(
        [FromBody] CreateItemRequest request,
        [FromServices] CreateItemHandler handler,
        CancellationToken cancellationToken = default)
    {
        var result = await handler.Handle(request, cancellationToken);
        if (result.IsFailure) return result.Error.ToResponse();

        return Ok(Envelope.Ok(result.Value));
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateMainInfo(
        [FromRoute] Guid id,
        [FromBody] UpdateMainInfoDTO dto,
        [FromServices] UpdateMainInfoHandler handler,
        [FromServices] IValidator<UpdateMainInfoRequest> validator,
        CancellationToken cancellationToken
        )
    {
        var request = new UpdateMainInfoRequest(id, dto);

        var validatorResult = await validator.ValidateAsync(request, cancellationToken);

        if (validatorResult.IsValid == false)
            return validatorResult.ToValidationErrorResponse();

        var result = await handler.Handle(request, cancellationToken);

        if (result.IsFailure)
            return result.Error.ToResponse();

        return Ok(result.Value);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(
        [FromRoute] Guid id,
        [FromServices] DeleteItemHandler handler,
        CancellationToken cancellationToken
        )
    {
        var request = new DeleteItemRequest(id);

        var result = await handler.Handle(request, cancellationToken);

        if (result.IsFailure)
            return result.Error.ToResponse();

        return Ok(result.Value);
    }

    //[HttpGet]
    //public async Task<IActionResult> Get(CancellationToken ct = default)
    //{
    //    var items = await _repository.Get(ct);
    //    return Ok(items);
    //}

    //[HttpGet("{id:guid}")]
    //public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct = default)
    //{
    //    var item = await _repository.GetById(id, ct);
    //    if (item.IsFailure) return NotFound(item.Error);
    //    return Ok(item.Value);
    //}

    //[HttpGet("category/")]
    //public async Task<IActionResult> GetByCategory([FromQuery] Guid id, CancellationToken ct = default)
    //{
    //    var items = await _repository.GetByCategory(id, ct);
    //    return Ok(items);
    //}
}
