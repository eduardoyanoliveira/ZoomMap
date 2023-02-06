using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.ContractAggregate.ValueObjects;
using ZoomMap.Domain.CustomerAggregate.ValueObjects;
using ZoomMap.Domain.ServiceAppointmentAggregate.ValueObjects;

namespace ZoomMap.Domain.CustomerAggregate
{
    public sealed class Customer : AggregateRoot<CustomerId>
    {
        private List<ContractId> _contracts = new();
        public IReadOnlyList<ContractId> Contracts => _contracts.AsReadOnly();

        private List<ServiceAppointmentId> _serviceAppointments = new();
        public IReadOnlyList<ServiceAppointmentId> ServiceAppointments => _serviceAppointments.AsReadOnly();

        // Todo: CPF
        public string Name { get; }
        public string Surname { get; }
        public DateTime BirthDate { get; }
        public string Email { get; }
        // Todo: Address

        private Customer(
            CustomerId customerId,
            string name,
            string surname,
            DateTime birthDate,
            string email
        )
            :base(customerId)
        {
            Name= name;
            Surname= surname;
            BirthDate = birthDate;
            Email = email;
        }

        public static Customer Create(
            string name,
            string surname,
            DateTime birthDate,
            string email
        )
        {
            return new Customer(
               CustomerId.CreateUnique(),
               name,
               surname,
               birthDate,
               email
            );
        }
    }
}
