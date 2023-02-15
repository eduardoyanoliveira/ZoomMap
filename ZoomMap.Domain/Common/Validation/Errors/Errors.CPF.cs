using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Domain.Common.Validation.Errors
{
    public static partial class Errors
    {
        public static class CPF
        {
            public static Error InvalidValue = Error.Validation(
                    code: "CPF.InvalidValue",
                    description: $"CPF value is not valid"
            );

            public static Error EmptyCPF = Error.Validation(
                   code: "CPF.EmptyValue",
                   description: "CPF can not be empty or valueless"
            );

            public static Error CPFLength = Error.Validation(
                  code: "CPF.CPFLength",
                  description: "CPF length must be 11"
            );

            public static Error CPFSequential = Error.Validation(
                  code: "CPF.CPFSequential",
                  description: "CPF can not be a sequence of the same number"
            );
        }
    }
}
