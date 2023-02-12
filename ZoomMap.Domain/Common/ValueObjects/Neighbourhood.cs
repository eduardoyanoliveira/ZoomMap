using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationMediators;

namespace ZoomMap.Domain.Common.ValueObjects
{
    public sealed class Neighbourhood : ValueObject
    {
        public string Name { get; }

        private static readonly NeighbourhoodValidationMediator validationMediator = 
            NeighbourhoodValidationMediator.Create();
        private Neighbourhood(string name)
        {
            Name = name;
        }
        public static Result<Neighbourhood> Create(string name)
        {
            return Result<Neighbourhood>.Ok(new Neighbourhood(name));
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
