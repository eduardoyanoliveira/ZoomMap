using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Common.Validation.Base;
using ZoomMap.Domain.Validation.Errors;

namespace ZoomMap.Domain.Common.ValueObjects
{
    public sealed class CPF : ValueObject
    {

        public const int MaxLenght = 11;

        public CPF(string value) 
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<CPF> Create(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return Result<CPF>.Fail(Errors.CPF.EmptyCPF);
            }

            if(value.Length > MaxLenght)
            {
                return Result<CPF>.Fail(Errors.CPF.TooLong);
            }

            return Result<CPF>.Ok(new CPF(value));
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
