using ASP.NET_Core_Web_API.Models.DTO;
using ASP.NET_Core_Web_API.Models.Implementation;

namespace ASP.NET_Core_Web_API.Domain.Interfaces
{
    public interface IOperationManager : IManager<Operation>
    {
        Task <Guid> Create(OperationCreate operation);

    }
}
