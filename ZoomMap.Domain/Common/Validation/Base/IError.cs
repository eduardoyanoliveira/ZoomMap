namespace ZoomMap.Domain.Common.Validation.Base
{
    public interface IError
    {
        List<Error>? Errors { get; }
        bool IsError { get; }
    }
}
