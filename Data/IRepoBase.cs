namespace ASP.NET_Core_Web_API.Data
{
    public interface IRepoBase<T>
    {
        T GetItem(Guid id);
        IEnumerable<T> GetList();
        void Update(T value);
        void Add(T value);
    }
}
