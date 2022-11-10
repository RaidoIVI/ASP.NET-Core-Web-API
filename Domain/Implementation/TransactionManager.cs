using ASP.NET_Core_Web_API.Data.Interfaces;
using ASP.NET_Core_Web_API.Domain.Interfaces;
using ASP.NET_Core_Web_API.Models.DTO;
using ASP.NET_Core_Web_API.Models.DTO.Transaction;
using ASP.NET_Core_Web_API.Models.Implementation;
using ASP.NET_Core_Web_API.Models;

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
            if (updated != null)
            {
                if (item.Date != null) updated.Date = item.Date.Value;
                if (item.Value != null) updated.Value = item.Value.Value;
                if (item.OperationId != null) updated.OperationId = item.OperationId.Value;
                await _transactionRepo.Update(updated);
            }
        }
        private async Task<Report> ReportOperation(Guid operationId, DateTime dateStart, DateTime dateEnd)
        {
            var dbData = await _transactionRepo.GetList(operationId, dateStart, dateEnd);
            if (dbData == null) return null;
            var result = new Report
            {
                DateStart = dateStart,
                DateEnd = dateEnd,
                OperationId = operationId
            };
            await Task.Run(() =>
            {
                foreach (var item in dbData)
                {
                    result.Value += item.Value;
                }
            });
            return result;
        }
        public async Task<ReportToFront[]> GetReport(Guid[] operationId, DateTime startDate, DateTime endDate)
        {
            var result = new List<ReportToFront>();
            foreach (var item in operationId)
            {
                var start = await ReportOperation(item, DateTime.MinValue, startDate);
                var end = await ReportOperation(item, startDate, endDate);
                result.Add( new ReportToFront
                {
                    OperationId = item,
                    Date = endDate,
                    ValueAbs = end.Value - start.Value,
                    ValueEnd = end.Value,
                    ValuePercent = end.Value / (start.Value==0 ? 1:start.Value) * 100,
                    ValueStart = start.Value
                });
            }
            return result.ToArray();
        }
    }
}
