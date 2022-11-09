using ASP.NET_Core_Web_API.Domain.Interfaces;
using ASP.NET_Core_Web_API.Models.DTO.Operation;
using ASP.NET_Core_Web_API.Models.DTO.Transaction;
using ASP.NET_Core_Web_API.Models.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NET_Core_Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionManager _transactionManager;

        public TransactionController(ITransactionManager transactionManager)
        {
            _transactionManager = transactionManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var result = await _transactionManager.GetItem(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _transactionManager.GetList();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransactionCreate transaction)
        {
            var result = await _transactionManager.Create(transaction);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TransactionUpdate transaction)
        {
            await _transactionManager.Update(transaction);
            return Ok();
        }

        [HttpDelete]
        public async Task Remove(Guid id)
        {
            await _transactionManager.Delete(id);
        }
    }
}
