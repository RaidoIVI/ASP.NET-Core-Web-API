using ASP.NET_Core_Web_API.Data.Interfaces;
using ASP.NET_Core_Web_API.Domain.Interfaces;
using ASP.NET_Core_Web_API.Models.DTO;
using ASP.NET_Core_Web_API.Models.Implementation;

namespace ASP.NET_Core_Web_API.Domain.Implementation
{
    public class TransactionManager : ITransactionManager
    {
        private readonly ITransactionsRepo _transactionRepo;

        public TransactionManager(ITransactionsRepo transactionRepo)
        {
            _transactionRepo = transactionRepo;
        }

        public async Task<Guid> Create(TransactionCreate transactions)
        {
            var result = new Transaction
            {
                Id = Guid.NewGuid(),
                Name = transactions.Name,
                OperationId = transactions.OperationId,
                Value = transactions.Value,
                Date = transactions.Date
            };
            await _transactionRepo.Add(result);
            return result.Id;
        }

        public async Task<IEnumerable<Transaction>> GetList()
        {
            var result = await _transactionRepo.GetList();
            return result;
        }

        public async Task<Transaction> GetItem(Guid id)
        {
            var result = await _transactionRepo.GetItem(id);
            return result;
        }

        public async Task Update(Transaction item)
        {
            await _transactionRepo.Update(item);
        }
    }
}
