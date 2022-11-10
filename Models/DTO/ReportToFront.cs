namespace ASP.NET_Core_Web_API.Models.DTO
{
    public class ReportToFront
    {
        public Guid OperationId { get; set; }
        public DateTime Date { get; set; }
        public decimal ValueStart { get; set; }
        public decimal ValueEnd { get; set; }
        public decimal ValueAbs { get; set; }
        public decimal ValuePercent { get; set; }
    }
}
