using ASP.NET_Core_Web_API.Domain.Interface;
using ASP.NET_Core_Web_API.Models.DTO;
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

        [HttpGet("{ID}")]
        public IActionResult GetItem(Guid id)
        {
            var result = _transactionManager.GetItem(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _transactionManager.GetList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(TransactionCreate transaction)
        {
            var result = _transactionManager.Create(transaction);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(Transaction transaction)
        {
            _transactionManager.Update(transaction);
            return Ok();
        }
    }
}
