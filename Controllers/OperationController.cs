﻿// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


using ASP.NET_Core_Web_API.Domain.Interface;
using ASP.NET_Core_Web_API.Models.DTO;
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

        [HttpGet("{ID}")]
        public IActionResult GetItem(Guid id)
        {
            var result = _operationManager.GetItem(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _operationManager.GetList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] OperationCreate operation)
        {
            var result = _operationManager.Create(operation);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Operation operation)
        {
            _operationManager.Update(operation);
            return Ok();
        }

    }
}