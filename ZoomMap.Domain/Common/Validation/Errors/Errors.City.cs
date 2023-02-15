using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Domain.Common.Validation.Errors
{
    public static partial class Errors
    {
        public static class City
        {
            public static Error NotEmptyName = Error.Validation(
                 code: "City.NotEmptyName",
                 description: "The city name can be empty"
            );

        }
    }
}
