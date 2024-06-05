namespace solution.Exceptions;

public class CategoryValidationException(Dictionary<string, string[]> errors) : Exception
{
    public Dictionary<string, string[]> Errors { get; } = errors;
}