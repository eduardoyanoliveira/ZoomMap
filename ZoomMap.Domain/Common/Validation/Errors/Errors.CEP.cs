using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Domain.Validation.Errors
{
    public static partial class Errors
    {
        public static class CEP
        {
            public static Error InvalidPostalCode = Error.Validation(
                 code: "Address.InvalidPostalCode",
                 description: "The given postal code does not exist!"
            );

        }
    }
}
