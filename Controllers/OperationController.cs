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
        /// <summary>
        /// Предоставляет операцию по ее Guid (ID)
        /// </summary>
        /// <param name="id"></param> ID для поиска
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var result = await _operationManager.GetItem(id);
            return result != null ? Ok(result) : BadRequest("Объект не найден");

        }
        /// <summary>
        /// Предоставляет список операций
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _operationManager.GetList();
            return Ok(result);
            
        }
        /// <summary>
        /// Создает новую операцию
        /// </summary>
        /// <param name="operation"></param> Название операции
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(OperationCreate operation)
        {
            var result = await _operationManager.Create(operation);
            return Ok(result);
            
        }
        /// <summary>
        /// Изменяет название операции
        /// </summary>
        /// <param name="operationEdit"></param> Новое название
        /// <returns></returns>
        [HttpPut]
        public async Task Update(OperationEdit operationEdit)
        {
            var operation = new Operation
            {
                Id = operationEdit.Id,
                Name = operationEdit.Name
            };
            await _operationManager.Update(operation);
  
        }
        /// <summary>
        /// Удаляет операцию по ID
        /// </summary>
        /// <param name="id"></param> ID операции для удаления
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _operationManager.Delete(id);
        }
    }
}
