namespace ASP.NET_Core_Web_API.Models.DTO.Transaction
{
    public class TransactionGet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OperationName { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
    }
}
