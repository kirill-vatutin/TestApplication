namespace TestApplication.API.Response;


public record ResponseError(string? ErrorCode, string? ErrorMessage, string? InvalidField);

public record Envelope
{
    public object? Result { get; set; }

    public List<ResponseError> Errors { get; set; }

    public DateTime? TimeGenerated { get; set; }

    private Envelope(object? result, IEnumerable<ResponseError> errors)
    {
        Result = result;
        Errors = errors.ToList();
        TimeGenerated = DateTime.Now;
    }

    public static Envelope Ok(object? result = null) =>
        new(result, []);

    public static Envelope Error(IEnumerable<ResponseError> errors) =>
        new(null, errors);
}
