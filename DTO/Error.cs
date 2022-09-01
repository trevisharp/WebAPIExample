public class Error
{
    public string Message { get; set; }
    public string Field { get; set; }

    public static Error Create(string field, string message)
    {
        Error error = new Error();
        error.Field = field;
        error.Message = message;
        return error;
    }
}