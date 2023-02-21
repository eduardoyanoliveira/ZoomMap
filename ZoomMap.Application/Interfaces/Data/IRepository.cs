namespace ZoomMap.Application.Interfaces.Data
{
    public interface IRepository<T>
    {
        T GetById(Guid id);
        void Update(T entity);
        void Save(T entity);
    }
}
