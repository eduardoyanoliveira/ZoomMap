namespace ZoomMap.Domain.Common.Models
{
    public sealed class ValueObjectUtils
    {
        public static T FromString<T>(string id) where T : ValueObject
        {
            var constructor = typeof(T).GetConstructor(new[] { typeof(Guid) });
            if (constructor == null)
            {
                throw new InvalidOperationException($"{typeof(T)} does not have a constructor that takes a Guid argument.");
            }

            if (!Guid.TryParse(id, out var guid))
            {
                throw new ArgumentException("Invalid ID string", nameof(id));
            }

            return (T)constructor.Invoke(new object[] { guid });
        }
    }
}
