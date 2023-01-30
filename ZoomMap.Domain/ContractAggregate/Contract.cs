using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.ContractAggregate.ValueObjects;
using ZoomMap.Domain.CustomerAggregate.ValueObjects;
using ZoomMap.Domain.SellerAggregate.ValueObjects;
using ZoomMap.Domain.ServiceAppointmentAggregate.ValueObjects;


namespace ZoomMap.Domain.ContractAggregate
{
    public sealed class Contract : AggregateRoot<ContractId>
    {
        private readonly List<ServiceAppointmentId> _serviceAppointments = new();

        public int Number { get; }
        public SellerId SellerId { get; }
        public CustomerId CustomerId { get; }

        public IReadOnlyList<ServiceAppointmentId> ServiceAppointments => _serviceAppointments.AsReadOnly();

        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public DateTime ProgrammedEndDateTime { get; }

        private Contract(
           ContractId contractId,
           int number,
           SellerId sellerId,
           CustomerId customerId,
           DateTime startDateTime,
           DateTime programmedEndDateTime,
           DateTime endDateTime
        ) : base(contractId)
        {
            Number = number;
            SellerId = sellerId;
            CustomerId = customerId;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            ProgrammedEndDateTime = programmedEndDateTime;
        }

        public static Contract Create(
          int number,
          SellerId sellerId,
          CustomerId customerId,
          DateTime startDateTime,
          DateTime programmedEndDateTime,
          DateTime endDateTime
        )
        {
            return new Contract(
                ContractId.CreateUnique(),
                number,
                sellerId,
                customerId,
                startDateTime,
                programmedEndDateTime,
                endDateTime);
        }
    }
}
