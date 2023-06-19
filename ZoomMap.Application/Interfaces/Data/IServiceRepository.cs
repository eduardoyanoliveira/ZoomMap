using ZoomMap.Application.Interfaces.Data.IAbstractRepositories;
using ZoomMap.Domain.Entities.ServiceEntity;

namespace ZoomMap.Application.Interfaces.Data
{
    public interface IServiceRepository : 
        IAbstractFilterRepository<Service>,
        IAbstractUpdateRepository<Service>,
        IAbstractAddRepository<Service>
    {

    }
}
