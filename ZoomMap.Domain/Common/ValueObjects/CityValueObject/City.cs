using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationBase;

namespace ZoomMap.Domain.Common.ValueObjects.CityValueObject
{
    public sealed class City : ValueObject
    {
        public string Name { get; }

        private static readonly IValidationMediator<City> _validationMediator
            = CityValidationMediator.Create();
        private City(string name)
        {
            Name = name;
        }

        public static Result<City> Create(string name)
        {
            City city = new City(name);

            return _validationMediator.ValidateBatch(city);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
