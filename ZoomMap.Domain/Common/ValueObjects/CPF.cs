using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationMediators;

namespace ZoomMap.Domain.Common.ValueObjects
{
    public sealed class CPF : ValueObject
    {
        private CPF(string value) 
        {
            Value = value;
        }

        public string Value { get; }
        private static readonly CPFValidationMediator _validationMediator 
            = CPFValidationMediator.Create();

        public static Result<CPF> Create(string value)
        {
            CPF CPF = new CPF(value);
            return _validationMediator.ValidateBatch(CPF);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
