namespace ASP.NET_Core_Web_API.Domain
{
    public interface IManager<T>
    {
        T GetItem(Guid id);
        IEnumerable<T> GetList();
        void Update(T item);
    }
}
