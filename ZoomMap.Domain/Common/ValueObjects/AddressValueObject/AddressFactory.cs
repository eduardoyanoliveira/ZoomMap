using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.ValueObjects.CEPValueObject;
using ZoomMap.Domain.Common.ValueObjects.CityValueObject;
using ZoomMap.Domain.Common.ValueObjects.NeighbourhoodValueObject;

namespace ZoomMap.Domain.Common.ValueObjects.AddressValueObject
{
    public static class AddressFactory
    {
        public static Result<Address> Create(
            int locationNumber,
            string cep,
            string neighbourhood,
            string street,
            string cityName
        )
        {
            var cityResult = City.Create(cityName);

            if (cityResult.IsFailure)
            {
                return Result<Address>.Fail(cityResult.Error);
            }

            var cepResult = CEP.Create(cep);

            if (cepResult.IsFailure)
            {
                return Result<Address>.Fail(cepResult.Error);
            }

            var neighbourhoodResult = Neighbourhood.Create(neighbourhood);

            if (neighbourhoodResult.IsFailure)
            {
                return Result<Address>.Fail(neighbourhoodResult.Error);
            }

            var addressResult = Address.Create(
                locationNumber,
                cepResult.GetValue(),
                neighbourhoodResult.GetValue(),
                street,
                cityResult.GetValue()
            );

            if (addressResult.IsFailure)
            {
                return Result<Address>.Fail(addressResult.Error);
            }

            return Result<Address>.Ok(addressResult.GetValue());
        }
    }
}


