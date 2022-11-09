using ASP.NET_Core_Web_API.Models.Interfaces;

namespace ASP.NET_Core_Web_API.Models.Implementation
{
    public class Operation : IOperation
    {

        public ICollection<Transaction> Transactions { get; set; }
        /// <summary>
        ///     Информация о показателе
        /// </summary>

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Numer { get; set; }
    }
}
