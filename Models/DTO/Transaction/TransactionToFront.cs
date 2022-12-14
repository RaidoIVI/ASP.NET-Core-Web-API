using ASP.NET_Core_Web_API.Models.DTO.Operation;

namespace ASP.NET_Core_Web_API.Models.DTO.Transaction
{
    public class TransactionToFront
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public string OperationName { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        
        public  OperationEdit Operation { get; set; }
    }
}
