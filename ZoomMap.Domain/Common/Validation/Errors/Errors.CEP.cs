using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Domain.Common.Validation.Errors
{
    public static partial class Errors
    {
        public static class CEP
        {
            public static Error InvalidPostalCodePattern = Error.Validation(
                 code: "Address.InvalidPostalCodePattern",
                 description: "The given postal code does not match the right pattern"
            );

        }
    }
}
