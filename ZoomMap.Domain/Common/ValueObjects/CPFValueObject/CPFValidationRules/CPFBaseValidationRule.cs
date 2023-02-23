using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Common.Validation.Errors;

namespace ZoomMap.Domain.Common.ValueObjects.CPFValueObject.CPFValidationRules
{
    public class CPFBaseValidationRule : IValidationRule<CPF>
    {
        private Error _error = Errors.CPF.InvalidValue;
        public Result<CPF> Validate(CPF entity)
        {
            if (!IsValid(entity.Value))
                return Result<CPF>.Fail(_error);

            return Result<CPF>.Ok(entity);
        }
        private bool IsValid(string cpfValue)
        {
            int[] cpf = cpfValue.Select(c => c - '0')
                .ToArray();

            int[] cpfWithoutDigits = new int[9];

            Array.Copy(cpf, cpfWithoutDigits, 9);

            int firstDigit = GetFirstVerifyingDigit(cpfWithoutDigits);
            int secondDigit = GetSecondVerifyingDigit(cpfWithoutDigits, firstDigit);

            return cpf[9] == firstDigit && cpf[10] == secondDigit;
        }

        private int GetFirstVerifyingDigit(int[] cpf)
        {
            var mod = Enumerable.Range(2, 9).Reverse().Select((x, i) =>  x * cpf[i]).Sum() % 11;

            int digit = mod < 2 ? 0 : 11 - mod;

            return digit;
        }

        private int GetSecondVerifyingDigit(int[] cpf, int firstDigit)
        {
            int[] newCpf = new int[10];

            Array.Copy(cpf, newCpf, 9);
            newCpf[9] = firstDigit;

             var mod = Enumerable.Range(2, 10).Reverse().Select((x, i) =>  x * cpf[i]).Sum() % 11;
            int digit = mod < 2 ? 0 : 11 - mod;

            return digit;
        }
    }
}
