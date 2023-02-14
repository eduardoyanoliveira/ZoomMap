using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Domain.Common.Validation.Errors
{
    public static partial class Errors
    {
        public static class Neighbourhood
        {
            public static Error NotEmptyName = Error.Validation(
                 code: "Neighbourhood.NotEmptyName",
                 description: "The neighbourhood name can be empty"
            );

        }
    }
}
