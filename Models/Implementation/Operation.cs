using ASP.NET_Core_Web_API.Models.Interface;

namespace ASP.NET_Core_Web_API.Models.Implementation
{
    public class Operation : IOperation
    {
        /// <summary>
        /// Информация о показателе
        /// </summary>

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
