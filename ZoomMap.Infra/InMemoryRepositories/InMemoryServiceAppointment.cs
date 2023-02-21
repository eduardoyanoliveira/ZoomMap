using ZoomMap.Domain.Aggregates.ServiceAppointmentAggregate;
using ZoomMap.Domain.Entities.ServiceEntity.ValueObjects;

namespace ZoomMap.Infra.InMemoryData
{
    public class InMemoryServiceAppointment
    {
        private List<ServiceAppointment> _serviceAppointments;

        public InMemoryServiceAppointment(List<ServiceAppointment> serviceAppointments)
        {
            _serviceAppointments = serviceAppointments;
        }

        public void Save(ServiceAppointment serviceAppointment)
        {
            _serviceAppointments.Add(serviceAppointment);
        }

        public void Delete(ServiceAppointment serviceAppointment)
        {
            _serviceAppointments.Remove(serviceAppointment);
        }

        public List<ServiceAppointment> GetByServiceId(ServiceId serviceId)
        {
            return _serviceAppointments.Where(x => x.ServiceId== serviceId).ToList();
        }
    }
}
