using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Common.ValueObjects;

namespace ZoomMap.Domain.Common.Validation.ValidationRules.CPFValidationRules
{
    public class CPFBaseValidationRule : IValidationRule<CPF>
    {
        private Error _error = Errors.Errors.CPF.InvalidValue;
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
            int sum = 0;
            int count = 0;

            for (int i = 10; i >= 2; i--)
            {
                sum += i * cpf[count];
                count++;
            }

            int mod = sum % 11;
            int digit = mod < 2 ? 0 : 11 - mod;

            return digit;
        }

        private int GetSecondVerifyingDigit(int[] cpf, int firstDigit)
        {
            int[] newCpf = new int[10];

            Array.Copy(cpf, newCpf, 9);
            newCpf[9] = firstDigit;

            int sum = 0;
            int count = 0;

            for (int i = 11; i >= 2; i--)
            {
                sum += i * newCpf[count];
                count++;
            }

            int mod = sum % 11;
            int digit = mod < 2 ? 0 : 11 - mod;

            return digit;
        }
    }
}
