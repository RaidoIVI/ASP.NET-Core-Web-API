namespace ASP.NET_Core_Web_API.Models
{
    public class Report
    {
        public Guid OperationId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal Value { get; set; }
        
    }
}
