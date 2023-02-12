using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Domain.Validation.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials = Error.Validation(
                code: "Auth.InvalidCredentials",
                description: "Invalid Credentials");
        }
    }
}
