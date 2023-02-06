using ZoomMap.Domain.Common.Validation.Base;

namespace ZoomMap.Domain.Validation.Errors
{
    public static partial class Errors
    {
        public static class CPF
        {
            public static Error TooLong = Error.Conflict(
                    code: "CPF.TooLong",
                    description: $"CPF lenght is too long"
            );

            public static Error EmptyCPF = Error.Validation(
                   code: "CPF.EmptyValue",
                   description: "CPF can not be empty or valueless"
            );
        }
    }
}
