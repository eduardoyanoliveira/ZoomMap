using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Common.ValueObjects.CEPValueObject;
using ZoomMap.Domain.Common.ValueObjects.CityValueObject;
using ZoomMap.Domain.Common.ValueObjects.NeighbourhoodValueObject;

namespace ZoomMap.Domain.Common.ValueObjects.AddressValueObject
{
    public sealed class Address : ValueObject
    {
        public int LocationNumber { get; }
        public CEP CEP { get; }
        public Neighbourhood Neighbourhood { get; }
        public string Street { get; }
        public City City { get; }

        private static readonly IValidationMediator<Address> _validationMediator
            = AddressValidationMediator.Create();

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
            Neighbourhood = neighbourhood;
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
            Address address = new Address(
                locationNumber,
                cep,
                neighbourhood,
                street,
                city
            );

            return _validationMediator.ValidateBatch(address);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return LocationNumber;
            yield return CEP.GetHashCode();
            yield return Neighbourhood.GetHashCode();
            yield return Street;
            yield return City.GetHashCode();
        }
    }
}
