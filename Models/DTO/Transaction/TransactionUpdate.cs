namespace ASP.NET_Core_Web_API.Models.DTO.Transaction
{
    public class TransactionUpdate
    {
        public Guid TransactionId { get; set; }
        public Guid? OperationId { get; set; }
        public decimal? Value { get; set; }
        public DateTime? Date { get; set; }
    }
}
