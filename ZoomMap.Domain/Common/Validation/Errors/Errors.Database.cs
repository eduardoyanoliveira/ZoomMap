using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Domain.Common.Validation.Errors
{
    public static partial class Errors
    {
        public static class Database
        {
            public static Error InsertError = Error.Unexpected(
                code: "Database.Error",
                description: "Couldn't insert the register due an unexpected error");

            public static Error RegisterNotFound = Error.Unexpected(
               code: "Database.NotFoundError",
               description: "Couldn't find the register on database");
        }
    }
}
