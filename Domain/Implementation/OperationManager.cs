using ASP.NET_Core_Web_API.Data.Interfaces;
using ASP.NET_Core_Web_API.Domain.Interfaces;
using ASP.NET_Core_Web_API.Models.DTO.Operation;
using ASP.NET_Core_Web_API.Models.Implementation;

namespace ASP.NET_Core_Web_API.Domain.Implementation
{
    public class OperationManager : IOperationManager
    {
        private readonly IOperationsRepo _operationsRepo;

        public OperationManager(IOperationsRepo operationsRepo)
        {
            _operationsRepo = operationsRepo;
        }

        public async Task<Operation> GetItem(Guid id)
        {
            var result = await _operationsRepo.GetItem(id);
            return result;
        }

        public async Task<IEnumerable<Operation>> GetList()
        {
            var result = await _operationsRepo.GetList();
            return result;
        }

        public async Task Delete(Guid id)
        {
            await _operationsRepo.Delete(id);
        }

        public async Task<Guid> Create(OperationCreate operation)
        {
            var value = new Operation
            {
                Id = Guid.NewGuid(),
                Name = operation.Name

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
