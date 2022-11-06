using ASP.NET_Core_Web_API.Models.DTO;
using ASP.NET_Core_Web_API.Models.Implementation;

namespace ASP.NET_Core_Web_API.Domain.Interface
{
    public interface IOperationManager : IManager<Operation>
    {
        Guid Create(OperationCreate operation);

    }
}
