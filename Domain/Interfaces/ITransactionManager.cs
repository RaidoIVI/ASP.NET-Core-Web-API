using ASP.NET_Core_Web_API.Models.DTO;
using ASP.NET_Core_Web_API.Models.DTO.Operation;
using ASP.NET_Core_Web_API.Models.DTO.Transaction;
using ASP.NET_Core_Web_API.Models.Implementation;

namespace ASP.NET_Core_Web_API.Domain.Interfaces
{
    public interface ITransactionManager : IManager<Transaction>
    {
        Task<Guid> Create(TransactionCreate transaction);
        Task Update(TransactionUpdate transaction);
        Task<ReportToFront[]> GetReport(Guid[] operationId, DateTime dateStart, DateTime dateEnd);
    }
}
