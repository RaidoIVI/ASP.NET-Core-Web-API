using System.Data.Entity;
using ASP.NET_Core_Web_API.Data.Interfaces;
using ASP.NET_Core_Web_API.Models.Implementation;

namespace ASP.NET_Core_Web_API.Data.Implementation
{
    public class OperationsRepo : IOperationsRepo
    {
        private readonly StorageDbContext _storageDbContext;
        
        public OperationsRepo(StorageDbContext storageDbContext)
        {
            _storageDbContext = storageDbContext;
        }

        public async Task Add(Operation value)
        {
            await _storageDbContext.Operations.AddAsync(value);
            await _storageDbContext.SaveChangesAsync();
        }

        public async Task <Operation> GetItem(Guid id)
        {
            var result = await _storageDbContext.Operations.FindAsync(id) ;
            return result;
        }

        public async Task<IEnumerable<Operation>> GetList()
        {
            var result = await _storageDbContext.Operations.ToListAsync() ;
            return result;
        }

        public async Task Update(Operation value)
        {
            await Task.Run(() => _storageDbContext.Operations.Update(value));
            await _storageDbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var result = await GetItem(id);
            await Task.Run(() => _storageDbContext.Operations.Remove(result));
            await _storageDbContext.SaveChangesAsync();
        }
    }
}
