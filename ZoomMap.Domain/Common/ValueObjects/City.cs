using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Domain.Common.ValueObjects
{
    public sealed class City : ValueObject
    {
        public string Name { get; }

        private City(string name)
        {
            Name = name;
        }

        public static Result<City> Create(string name)
        {
            return Result<City>.Ok(new City(name));
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
