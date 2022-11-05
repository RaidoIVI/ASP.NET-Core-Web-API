namespace ASP.NET_Core_Web_API.Models.Interface
{
    public interface ITransaction : IModel
    {
        Guid OperationId { get; set; }
        Decimal Value { get; set; }
        DateTime Date { get; set; }
    }
}
