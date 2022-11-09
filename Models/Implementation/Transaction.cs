using ASP.NET_Core_Web_API.Models.Interfaces;

namespace ASP.NET_Core_Web_API.Models.Implementation
{
    public class Transaction : ITransaction
    {

        public Operation Operation { get; set; }
        /// <summary>
        ///     Информация о операции (транзакции)
        /// </summary>

        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public int Numer { get; set; }
        public Guid OperationId { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
    }
}
