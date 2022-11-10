﻿using System.ComponentModel;
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
        public async Task <IActionResult> GetItem(Guid id)
        {
            var resultDb = await _transactionManager.GetItem(id);
            var result = await Task.Run(() => new TransactionToFront
            {
                Date = resultDb.Date,
                Id = resultDb.Id,
                Name = resultDb.Name,
                Operation = new OperationEdit
                    {
                        Name = resultDb.Operation.Name,
                        Id = resultDb.OperationId
                        
                    },
                Value = resultDb.Value
            });
            return result == null ? BadRequest ("Объект не найден") : Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var resultDb = await _transactionManager.GetList();
            var result = await Task.Run<IEnumerable<TransactionToFront>> (() =>
            {
                return resultDb.Select(transaction => new TransactionToFront
                    {
                        Date = transaction.Date,
                        Id = transaction.Id,
                        Name = transaction.Name,
                        Operation = new OperationEdit
                        {
                            Name = transaction.Operation.Name,
                            Id = transaction.OperationId
                        },
                        Value = transaction.Value
                    }).
                    ToList();
            });
            return Ok(result);
        }

        [HttpPost("{date-time}")]
        public async Task<IActionResult> GetReport(DateTime date,[FromBody] Guid[] operationId)
        {
            var result = await _transactionManager.GetReport(operationId,date.AddYears(-1),date);
            return result != null ? Ok(result) : BadRequest("По запросу нет данных");
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(TransactionCreate transaction)
        {
            var result = await _transactionManager.Create(transaction);
            return result != null ? Ok(result) : BadRequest("Не получилось создать объект");
        }

        [HttpPut]
        public async Task Update(TransactionUpdate transaction)
        {
            await _transactionManager.Update(transaction);
        }

        [HttpDelete]
        public async Task Remove(Guid id)
        {
            await _transactionManager.Delete(id);
        }
    }
}
