// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


using ASP.NET_Core_Web_API.Domain.Interfaces;
using ASP.NET_Core_Web_API.Models.DTO.Operation;
using ASP.NET_Core_Web_API.Models.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperationController : ControllerBase
    {
        private readonly IOperationManager _operationManager;

        public OperationController(IOperationManager operationManager)
        {
            _operationManager = operationManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var result = await _operationManager.GetItem(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _operationManager.GetList();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OperationCreate operation)
        {
            var result = await _operationManager.Create(operation);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(OperationEdit operationEdit)
        {
            var operation = new Operation
            {
                Id = operationEdit.Id,
                Name = operationEdit.Name
            };
            await _operationManager.Update(operation);
            return Ok();
        }

        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _operationManager.Delete(id);
        }
    }
}
