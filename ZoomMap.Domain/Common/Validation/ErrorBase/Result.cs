namespace ZoomMap.Domain.Common.Validation.ErrorBase;

public class Result<T>
{
    public bool IsSuccess { get; protected set; }
    public bool IsFailure { get; protected set; }

    public Error Error;

    private T _value;

    private Result(bool isSuccess, Error? error = default, T? value = default)
    {
        if (isSuccess && error.HasValue)
        {
            throw new Exception($"InvalidOperation: A result cannot be successful and contain an {error}");
        }


        if (!isSuccess && !error.HasValue)
        {
            throw new Exception($"InvalidOperation: A failing result needs to contain an {error} message");
        }

        IsSuccess = isSuccess;
        IsFailure = !isSuccess;

        if (error != null)
            Error = (Error)error;

        if (value != null)
            _value = value;
    }

    public T GetValue()
    {

        if (!IsSuccess)
        {
            throw new Exception("Cant retrieve the value from a failed result.");
        }
        return _value;
    }

    public static Result<T> Ok(T value = default)
    {
        return new Result<T>(true, null, value);
    }

    public static Result<T> Fail(Error error)
    {
        return new Result<T>(false, error);
    }

}
