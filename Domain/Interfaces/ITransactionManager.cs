using ASP.NET_Core_Web_API.Models.DTO;
using ASP.NET_Core_Web_API.Models.Implementation;

namespace ASP.NET_Core_Web_API.Domain.Interfaces
{
    public interface ITransactionManager : IManager<Transaction>
    {
        Task <Guid> Create(TransactionCreate transactions);
    }
}
