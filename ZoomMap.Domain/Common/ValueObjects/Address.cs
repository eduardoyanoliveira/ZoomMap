using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Validation.Errors;

namespace ZoomMap.Domain.Common.ValueObjects
{
    public sealed class Address : ValueObject
    {
        public int LocationNumber { get; }
        public CEP CEP { get; }
        public Neighbourhood Neighbourhood { get; }
        public string Street { get; }
        public City City { get; }

        private Address(
            int locationNumber,
            CEP cep,
            Neighbourhood neighbourhood,
            string street,
            City city
        ) 
        {
            LocationNumber = locationNumber;
            CEP = cep;
            Neighbourhood= neighbourhood;
            Street = street;
            City = city;
        }

        public static Result<Address> Create(
            int locationNumber,
            CEP cep,
            Neighbourhood neighbourhood,
            string street,
            City city
        )
        {
            var result = CreateValidation(locationNumber, street);

            if (result.IsFailure)
            {
                return Result<Address>.Fail(result.Error);
            }

            var address = new Address(
                locationNumber,
                cep,
                neighbourhood,
                street,
                city
            );

            return Result<Address>.Ok(address);
        }

        private static Result<bool> CreateValidation(
            int locationNumber,
            string street
        )
        {
            if(locationNumber <= 0)
            {
                return Result<bool>.Fail(Errors.Address.InvalidLocationNumber);
            }

            if (String.IsNullOrWhiteSpace(street))
            {
                return Result<bool>.Fail(Errors.Address.InvalidStreetName);
            }

            return Result<bool>.Ok(true);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return LocationNumber;
            yield return CEP;
            yield return Neighbourhood;
            yield return Street;
            yield return City;
        }
    }
}
