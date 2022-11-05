using ASP.NET_Core_Web_API.Data.Interfaces;
using ASP.NET_Core_Web_API.Domain.Interface;
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

        public Operation GetItem(Guid id)
        {
            return _operationsRepo.GetItem(id);
        }

        public IEnumerable<Operation> GetList()
        {
            return _operationsRepo.GetList();
        }

        public Guid Create(OperationCreate operation)
        {
            var results = new Operation()
            {
                Id = Guid.NewGuid(),
                Name = operation.Name,

            };
            _operationsRepo.Add(results);
            return results.Id;
        }

        public void Update(Operation item)
        {
            _operationsRepo.Update(item);
        }
    }
}
