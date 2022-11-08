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
        }

        public async Task Add(Transaction value)
        {
            await _storageDbContext.Transactions.AddAsync(value);
            await _storageDbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var result = await GetItem(id);
            await Task.Run(() => _storageDbContext.Transactions.Remove(result));
            await _storageDbContext.SaveChangesAsync();
        }

        public async Task<Transaction> GetItem(Guid id)
        {
            var result = await _storageDbContext.Transactions.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<Transaction>> GetList()
        {
            var result = await _storageDbContext.Transactions.ToArrayAsync();
            return result;
        }

        public async Task Update(Transaction value)
        {
            await Task.Run(() => _storageDbContext.Transactions.Update(value));
            await _storageDbContext.SaveChangesAsync();
        }
    }
}
