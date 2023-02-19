using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Entities.SellerEntity.ValueObjects;
using ZoomMap.Domain.UserAggregate.ValueObjects;

namespace ZoomMap.Domain.Entities.SellerEntity
{
    public sealed class Seller : AggregateRoot<SellerId>
    {
        public string Name { get; }
        public string Surname { get; }
        public UserId UserId { get; }

        private Seller(
            SellerId id,
            string name,
            string surname,
            UserId userId
        ) : base(id)
        {
            Name = name;
            Surname = surname;
            UserId = userId;
        }

        public static Seller Create(
            string name,
            string surname,
            UserId userId
        )
        {
            return new Seller(
                SellerId.CreateUnique(),
                name,
                surname,
                userId
            );
        }
    }
}
