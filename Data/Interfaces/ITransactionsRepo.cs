using ASP.NET_Core_Web_API.Models.Implementation;

namespace ASP.NET_Core_Web_API.Data.Interfaces
{
    public interface ITransactionsRepo : IRepoBase<Transaction>
    {
        public Task<IEnumerable<Transaction>> GetList(Guid operationId, DateTime dateStart, DateTime dateEnd);
    }
}
