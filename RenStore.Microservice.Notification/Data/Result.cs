namespace RenStore.Microservice.Notification.Data;

public class Result<T>
{
    public bool IsSuccess { get; }
    public string Error { get; }
    
    private Result(T value, bool isSuccess, string error)
    {
        if (isSuccess && !string.IsNullOrWhiteSpace(error))
            throw new InvalidOperationException();
        if (!isSuccess && string.IsNullOrEmpty(error))
            throw new InvalidOperationException();
        
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result<T> Success(T value) => new Result<T>(value, true, string.Empty);
    public static Result<T> Failure(string error) => new Result<T>(default!, false, error);
}