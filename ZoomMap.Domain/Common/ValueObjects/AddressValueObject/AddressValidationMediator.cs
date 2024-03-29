﻿using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.GenericValidationRules;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Common.Validation.Errors;

namespace ZoomMap.Domain.Common.ValueObjects.AddressValueObject
{
    public class AddressValidationMediator : IValidationMediator<Address>
    {
        private readonly ValidationMediator<Address> _validationMediator;

        private AddressValidationMediator(ValidationMediator<Address> validationMediator)
        {
            _validationMediator = validationMediator;
        }

        public static AddressValidationMediator Create()
        {
            ValidationMediator<Address> validationMediator = new ValidationMediator<Address>(
                new List<IValidationRule<Address>>
                {
                    new NotEmptyValidationRule<Address>(
                        x => x.Street , Errors.Address.NullOrEmptyStreetName
                    ),
                    new GreaterThanZeroValidationRule<Address>(
                        x => x.LocationNumber, Errors.Address.InvalidLocationNumber
                    ),
                }
            );

            return new AddressValidationMediator(validationMediator);
        }

        public Result<Address> ValidateBatch(Address entity)
        {
            return _validationMediator.ValidateBatch(entity);
        }
    }
}
