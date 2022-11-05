namespace ASP.NET_Core_Web_API.Models.DTO
{
    public class TransactionCreate
    {
        public string Name { get; set; }
        public Guid OperationId { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
    }
}
