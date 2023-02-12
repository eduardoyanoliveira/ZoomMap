using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationMediators;

namespace ZoomMap.Domain.Common.ValueObjects
{
    public sealed class CEP : ValueObject
    {
        public string Code { get; }

        private static readonly CEPValidationMediator<CEP> _validationMediator = CEPValidationMediator<CEP>.Create();

        private CEP(string code)
        {
            Code = code;
        }

        public static Result<CEP> Create(string code)
        {
            CEP cep = new CEP(code);

            return _validationMediator.Validate(cep);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }
    }
}
