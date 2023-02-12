namespace ZoomMap.Domain.Common.Validation.ErrorBase
{
    public interface IError
    {
        List<Error>? Errors { get; }
        bool IsError { get; }
    }
}
