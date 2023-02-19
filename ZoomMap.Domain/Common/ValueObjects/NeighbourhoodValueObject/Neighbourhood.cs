using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using static ZoomMap.Domain.Common.Validation.Errors.Errors;

namespace ZoomMap.Domain.Common.ValueObjects.NeighbourhoodValueObject
{
    public sealed class Neighbourhood : ValueObject
    {
        public string Name { get; }

        private static readonly NeighbourhoodValidationMediator _validationMediator =
            NeighbourhoodValidationMediator.Create();
        private Neighbourhood(string name)
        {
            Name = name;
        }
        public static Result<Neighbourhood> Create(string name)
        {
            Neighbourhood neighbourhood = new Neighbourhood(name);

            return _validationMediator.ValidateBatch(neighbourhood);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
