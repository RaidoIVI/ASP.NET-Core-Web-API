using ASP.NET_Core_Web_API.Data.Interfaces;
using ASP.NET_Core_Web_API.Domain.Interface;
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

        public Guid Create(TransactionCreate transactions)
        {
            var result = new Transaction()
            {
                Id = Guid.NewGuid(),
                Name = transactions.Name,
                OperationId = transactions.OperationId,
                Value = transactions.Value,
                Date = transactions.Date,
            };
            _transactionRepo.Add(result);
            return result.Id;
        }

        public IEnumerable<Transaction> GetList()
        {
            return _transactionRepo.GetList();
        }

        public Transaction GetItem(Guid id)
        {
            return _transactionRepo.GetItem(id);
        }

        public void Update(Transaction item)
        {
            _transactionRepo.Update(item);
        }
    }
}
