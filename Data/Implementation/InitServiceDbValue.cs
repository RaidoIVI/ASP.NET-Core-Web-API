using ASP.NET_Core_Web_API.Models.Implementation;

namespace ASP.NET_Core_Web_API.Data.Implementation
{
    public static class InitServiceDbValue
    {
        private readonly static Guid _initialTransaction = Guid.Parse("de5a92d5-4257-4ac1-9c5e-58fbb718be82");
        private readonly static Guid _initialOperation = Guid.Parse("4ca0e667-e13b-41cf-a1db-880065a44713");


        public readonly static Operation InitialOperation = new Operation
        {
            Id = _initialOperation,
            Name = "Service",
            Numer = 0
        };
        
        public readonly static Transaction InitialTransaction = new Transaction
        {
            Date = DateTime.MinValue,
            Id = _initialTransaction,
            Name = "Service",
            Numer = 0,
            OperationId = _initialOperation,
            Value = 0
        };
    }
}
