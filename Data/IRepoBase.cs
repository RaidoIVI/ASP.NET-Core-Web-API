namespace ASP.NET_Core_Web_API.Data
{
    public interface IRepoBase<T>
    {
        Task<T> GetItem(Guid id);
        Task<IEnumerable<T>> GetList();
        Task Update(T value);
        Task Add(T value);
        Task Delete(Guid id);
    }
}
