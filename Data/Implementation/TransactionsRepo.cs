using ASP.NET_Core_Web_API.Data.Interfaces;
using ASP.NET_Core_Web_API.Models.Implementation;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API.Data.Implementation
{
    public class TransactionsRepo : ITransactionsRepo
    {
        private readonly StorageDbContext _storageDbContext;

        public TransactionsRepo(StorageDbContext storageDbContext)
        {
            _storageDbContext = storageDbContext;
            
            if (_storageDbContext.Transactions.Find(InitServiceDbValue.InitialTransaction.Id) == null)
            {
                _storageDbContext.Add(InitServiceDbValue.InitialTransaction);
                _storageDbContext.SaveChanges();
            }
        }

        public async Task Add(Transaction value)
        {
            var service = await _storageDbContext.Transactions.FindAsync(InitServiceDbValue.InitialTransaction.Id);
            service.Numer++;
            value.Name = service.Numer.ToString();
            value.Numer = service.Numer;
            await Task.Run(() => _storageDbContext.Transactions.Update(service));
            await _storageDbContext.Transactions.AddAsync(value);
            await _storageDbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            if (id != InitServiceDbValue.InitialTransaction.Id)
            {
                var result = await GetItem(id);
                await Task.Run(() => _storageDbContext.Transactions.Remove(result));
                await _storageDbContext.SaveChangesAsync();
            }
        }

        public async Task<Transaction> GetItem(Guid id)
        {
            if (id != InitServiceDbValue.InitialTransaction.Id)
            {
                var result = await _storageDbContext.Transactions.FindAsync(id);
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Transaction>> GetList()
        {
            var result = await _storageDbContext.Transactions.Where(t => t.Id!=InitServiceDbValue.InitialTransaction.Id).ToArrayAsync();
            return result;
        }

        public async Task Update(Transaction value)
        {
            if (value.Id != InitServiceDbValue.InitialTransaction.Id)
            {
                await Task.Run(() => _storageDbContext.Transactions.Update(value));
                await _storageDbContext.SaveChangesAsync();
            }
        }
    }
}
