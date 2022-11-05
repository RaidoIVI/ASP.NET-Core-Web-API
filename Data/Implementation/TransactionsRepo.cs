using ASP.NET_Core_Web_API.Data.Interfaces;
using ASP.NET_Core_Web_API.Models.Implementation;

namespace ASP.NET_Core_Web_API.Data.Implementation
{
    public class TransactionsRepo : ITransactionsRepo
    {
        private static List<Transaction> _transactions = new List<Transaction>()
        {
            new Transaction()
            {
                Id = Guid.Parse("928717D8-1671-7E55-56C8-5784D64A49E4"),
                Name = "001",
                Value = 479,
                OperationId = Guid.Parse("AA152B71-D06A-1AB9-65CA-332773D2C01E"),
                Date = new DateTime (2022, 11, 05, 12, 00, 00)
            },
            new Transaction()
            {
                Id = Guid.Parse("C68A36E4-8C87-6CE8-6D84-FB5E35A95BCC"),
                Name = "002",
                Value = 6297,
                OperationId= Guid.Parse("7811E126-15A2-B569-C8B2-54EC966CA4B2"),
                Date = new DateTime (2022, 11, 05, 12, 20, 15)
            },
            new Transaction()
            {
                Id = Guid.Parse("26A30BBF-E983-DB3D-E1F9-C69619889238"),
                Name = "003",
                Value = 7806,
                OperationId = Guid.Parse("57344AE9-478A-58BE-14B3-13209490FC6E"),
                Date = new DateTime (2022, 11, 06, 20, 50, 00)
            },
            new Transaction()
            {
                Id = Guid.Parse("55C538CF-739E-5F3F-577A-9E2BA388962C"),
                Name = "004",
                Value = 3810,
                OperationId = Guid.Parse("CDA7BDE0-AD48-13B8-6A76-184A02888278"),
                Date = new DateTime (2022, 10, 05, 16, 00, 00)
            },
            new Transaction()
            {
                Id = Guid.Parse("B02F9565-AAFC-A3F9-74AC-1971AEB6A8A9"),
                Name = "005",
                Value = 1810,
                OperationId = Guid.Parse("A146D9A5-28FA-B93D-C653-FBB63AE60116"),
                Date = new DateTime (2021, 12, 30, 21, 45, 32)
            }
        }
        ;
        public void Add(Transaction value)
        {
            _transactions.Add(value);
        }

        public Transaction GetItem(Guid id)
        {
            var result = _transactions.FirstOrDefault(t => t.Id == id);
            return result;
        }

        public IEnumerable<Transaction> GetList()
        {
            return _transactions;
        }

        public void Update(Transaction value)
        {
            int index = _transactions.IndexOf(_transactions.FirstOrDefault(o => o.Id == value.Id));
            _transactions[index] = value;
        }
    }
}
