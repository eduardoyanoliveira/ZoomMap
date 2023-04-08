using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Domain.Common.Validation.Errors
{
    public static partial class Errors
    {
        public static class Service
        {
            public static Error EmptyOrNullServiceName = Error.Validation(
                 code: "Service.EmptyOrNullServiceName",
                 description: "Name property can not be empty or null"
            );

            public static Error NotUniqueServiceName = Error.Conflict(
                code: "Service.EmptyOrNullServiceName",
                description: "Service with the given name already exists"
            );

            public static Error NotGreaterThanZeroPrice = Error.Validation(
                 code: "Service.NotGreaterThanZeroPrice",
                 description: "Price property must be greater than zero"
            );
        }
    }
}
