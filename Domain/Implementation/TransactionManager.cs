using ASP.NET_Core_Web_API.Data.Interfaces;
using ASP.NET_Core_Web_API.Domain.Interfaces;
using ASP.NET_Core_Web_API.Models.DTO.Operation;
using ASP.NET_Core_Web_API.Models.DTO.Transaction;
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

        public async Task<Guid> Create(TransactionCreate transaction)
        {
            Transaction result = new Transaction
            {
                Id = Guid.NewGuid(),
                OperationId = transaction.OperationId,
                Value = transaction.Value,
                Date = transaction.Date
            };
            await _transactionRepo.Add(result);
            return result.Id;
        }

        public async Task<IEnumerable<Transaction>> GetList()
        {
            var result = await _transactionRepo.GetList();
            return result;
        }

        public async Task Delete(Guid id)
        {
            await _transactionRepo.Delete(id);
        }

        public async Task<Transaction> GetItem(Guid id)
        {
            var result = await _transactionRepo.GetItem(id);
            
            return result;
        }

        public async Task Update(TransactionUpdate item)
        {
            var updated = await _transactionRepo.GetItem(item.TransactionId);
            if (item.Date != null) updated.Date = item.Date.Value;
            if (item.Value != null) updated.Value = item.Value.Value;
            if (item.OperationId != null) updated.OperationId = item.OperationId.Value;
            await _transactionRepo.Update(updated);
        }
    }
}
