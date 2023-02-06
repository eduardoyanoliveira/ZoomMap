using ZoomMap.Domain.Common.Validation.Base;

namespace ZoomMap.Domain.Validation.Errors
{
    public static partial class Errors
    {
        public static class Address
        {
            public static Error InvalidLocationNumber = Error.Conflict(
                code: "Address.InvalidLocationNumber",
                description: "The Location number must be greater than zero!"
            );

            public static Error InvalidStreetName = Error.Validation(
                code: "Address.InvalidStreetName",
                description: "The street name can not be empty!"
            );
        }
    }
}
