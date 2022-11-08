using ASP.NET_Core_Web_API.Data.Interfaces;
using ASP.NET_Core_Web_API.Domain.Interfaces;
using ASP.NET_Core_Web_API.Models.DTO;
using ASP.NET_Core_Web_API.Models.Implementation;

namespace ASP.NET_Core_Web_API.Domain.Implementation
{
    public class OperationManager : IOperationManager
    {
        private readonly IOperationsRepo _operationsRepo;

        public OperationManager(IOperationsRepo operationsRepo)
        {
            this._operationsRepo = operationsRepo;
        }

        public Task <Operation> GetItem(Guid id)
        {
            return _operationsRepo.GetItem(id);
        }

        public Task<IEnumerable<Operation>> GetList()
        {
            return _operationsRepo.GetList();
        }

        public async Task <Guid> Create(OperationCreate operation)
        {
            var value = new Operation()
            {
                Id = Guid.NewGuid(),
                Name = operation.Name,

            };
            await _operationsRepo.Add(value);
            return value.Id;
        }

        public async Task Update(Operation item)
        {
            await _operationsRepo.Update(item);
        }
    }
}
