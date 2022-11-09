namespace ASP.NET_Core_Web_API.Models.Interfaces
{
    public interface ITransaction : IModel
    {
        Guid OperationId { get; set; }
        decimal Value { get; set; }
        DateTime Date { get; set; }
    }
}
