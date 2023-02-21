using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Domain.Common.Validation.Errors
{
    public static partial class Errors
    {
        public static class Product
        {
            public static Error EmptyOrNullProductName = Error.Validation(
                 code: "Product.EmptyOrNullProductName",
                 description: "Name property can not be empty or null"
            );

            public static Error NotUniqueProductName = Error.Conflict(
                code: "Product.EmptyOrNullProductName",
                description: "Product with the given name already exists"
            );

            public static Error NotGreaterThanZeroPrice = Error.Validation(
                 code: "Product.NotGreaterThanZeroPrice",
                 description: "Price property must be greater than zero"
            );
        }
    }
}
