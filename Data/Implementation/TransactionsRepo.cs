using ASP.NET_Core_Web_API.Data.Interfaces;
using ASP.NET_Core_Web_API.Models.Implementation;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API.Data.Implementation
{
    public class TransactionsRepo : ITransactionsRepo
    {
        private readonly TransactionsDbContext _transactionsDbContext;

        public TransactionsRepo(TransactionsDbContext transactionsDbContext)
        {
            _transactionsDbContext = transactionsDbContext;
        }

        public async Task Add(Transaction value)
        {
            await _transactionsDbContext.Transactions.AddAsync(value);
            await _transactionsDbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            //
        }

        public async Task<Transaction> GetItem(Guid id)
        {
            var result = await _transactionsDbContext.Transactions.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<Transaction>> GetList()
        {
            var result = await _transactionsDbContext.Transactions.ToArrayAsync();
            return result;
        }

        public async Task Update(Transaction value)
        {
            var result = await Task.Run(_transactionsDbContext.Transactions.Update(value));

            // int index = _transactions.IndexOf(_transactions.FirstOrDefault(o => o.Id == value.Id));
            // _transactions[index] = value;
        }
    }
}
