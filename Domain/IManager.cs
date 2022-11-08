namespace ASP.NET_Core_Web_API.Domain
{
    public interface IManager<T>
    {
        Task<T> GetItem(Guid id);
        Task<IEnumerable<T>> GetList();
        Task Update(T item);
    }
}
