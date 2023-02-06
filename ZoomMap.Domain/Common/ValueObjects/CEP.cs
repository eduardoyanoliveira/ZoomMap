using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Common.Validation.Base;
using ZoomMap.Domain.Validation.Errors;

namespace ZoomMap.Domain.Common.ValueObjects
{
    public sealed class CEP : ValueObject
    {
        public string Code { get; }

        private CEP(string code)
        {
            Code = code;
        }

        public static Result<CEP> Create(string code)
        {
            if (IsValid(code))
                return Result<CEP>.Fail(Errors.CEP.InvalidPostalCode);

            return Result<CEP>.Ok(new CEP(code));
        }

        private static bool IsValid(string code)
        {
            return code.Length == 8 && int.TryParse(code, out int n);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }
    }
}
