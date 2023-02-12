namespace ZoomMap.Domain.Common.Validation.ErrorBase
{
    public readonly struct Error
    {

        public string Code { get; }

        public string Description { get; }

        public ErrorType Type { get; }

        public Error(string code, string description, ErrorType type)
        {
            Code = code;
            Description = description;
            Type = type;
        }

        public static Error Conflict(string code = "General.Conflict", string description = "A conflict error has occurred.")
        {
            return new Error(
                code,
                description,
                ErrorType.Conflict
            );
        }

        public static Error Failure(string code = "General.Failure", string description = "A failure has occurred.")
        {
            return new Error(
               code,
               description,
               ErrorType.Failure
           );
        }

        public static Error NotFound(string code = "General.NotFound", string description = "A 'Not Found' error has occurred.")
        {
            return new Error(
               code,
               description,
               ErrorType.NotFound
           );
        }

        public static Error Unexpected(string code = "General.Unexpected", string description = "An unexpected error has occurred.")
        {
            return new Error(
              code,
              description,
              ErrorType.Failure
            );
        }

        public static Error Validation(string code = "General.Validation", string description = "A validation error has occurred.")
        {
            return new Error(
              code,
              description,
              ErrorType.Validation
            );
        }

    }
}
