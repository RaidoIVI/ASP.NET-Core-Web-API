using ASP.NET_Core_Web_API.Data.Interfaces;
using ASP.NET_Core_Web_API.Models.Implementation;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API.Data.Implementation
{
    public class OperationsRepo : IOperationsRepo
    {
        private readonly StorageDbContext _storageDbContext;

        public OperationsRepo(StorageDbContext storageDbContext)
        {
            _storageDbContext = storageDbContext;
            if (_storageDbContext.Operations.Find(InitServiceDbValue.InitialOperation.Id) == null)
            {
                _storageDbContext.Operations.Add(InitServiceDbValue.InitialOperation);
                _storageDbContext.SaveChanges();
            }
        }

        public async Task Add(Operation value)
        {
            var service = await _storageDbContext.Operations.FindAsync(InitServiceDbValue.InitialOperation.Id);
            service.Numer++;
            value.Numer = service.Numer;
            await Task.Run(() => _storageDbContext.Operations.Update(service));
            await _storageDbContext.Operations.AddAsync(value);
            await _storageDbContext.SaveChangesAsync();
        }

        public async Task<Operation> GetItem(Guid id)
        {
            if (id != InitServiceDbValue.InitialOperation.Id)
            {
                var result = await _storageDbContext.Operations.FindAsync(id);
                return result;
            }

            return null;
        }

        public async Task<IEnumerable<Operation>> GetList()
        {
            var result = await _storageDbContext.Operations.Where(t => t.Id != InitServiceDbValue.InitialOperation.Id).ToArrayAsync();
            return result;
        }

        public async Task Update(Operation value)
        {
            if (value.Id != InitServiceDbValue.InitialOperation.Id)
            {
                await Task.Run(() => _storageDbContext.Operations.Update(value));
                await _storageDbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            if (id != InitServiceDbValue.InitialOperation.Id)
            {
                var result = await GetItem(id);
                await Task.Run(() => _storageDbContext.Operations.Remove(result));
                await _storageDbContext.SaveChangesAsync();
            }
        }
    }
}
