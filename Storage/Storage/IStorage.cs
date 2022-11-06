namespace Storage
{
    public interface IStorage<T> where T : class
    {
        public IStorage<T> Get(int index);
        public IStorage<T>[] Get();
        public bool Set(IStorage<T> value);
        public bool Remove(int index);
        public bool Update(IStorage<T> value);
    }
}
