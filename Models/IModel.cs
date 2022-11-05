namespace ASP.NET_Core_Web_API.Models
{
    public interface IModel
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
