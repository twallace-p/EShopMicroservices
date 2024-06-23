namespace BuildingBlocks.Exceptions;

public class BadRequestExceptoin : Exception
{
    public BadRequestExceptoin(string message) : base(message) { }

    public BadRequestExceptoin(string message, string details) : base(message)
    {
        Details = details;
    }
 
    public string? Details { get; } 
}
