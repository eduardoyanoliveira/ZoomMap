using ZoomMap.Domain.Aggregates.ServiceAppointmentAggregate;
using ZoomMap.Domain.Entities.ServiceEntity.ValueObjects;

namespace ZoomMap.Application.Interfaces.Data
{
    public  interface IServiceAppointmentRepository
    {
        public void Save(ServiceAppointment serviceAppointment);
        public void Update(ServiceAppointment serviceAppointment);
        public void Delete(ServiceAppointment serviceAppointment);
        public List<ServiceAppointment> GetByServiceId(ServiceId serviceId);
    }
}
