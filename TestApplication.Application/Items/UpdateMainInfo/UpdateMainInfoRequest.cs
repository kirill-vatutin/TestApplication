namespace TestApplication.Application.Items.UpdateMainInfo;

public record UpdateMainInfoRequest(
    Guid Id,
    UpdateMainInfoDTO Dto);

public record UpdateMainInfoDTO(
    string Name,
    string Description,
    decimal Price,
    int Count
    );
