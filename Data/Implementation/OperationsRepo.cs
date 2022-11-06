using ASP.NET_Core_Web_API.Data.Interfaces;
using ASP.NET_Core_Web_API.Models.Implementation;

namespace ASP.NET_Core_Web_API.Data.Implementation
{
    public class OperationsRepo : IOperationsRepo
    {
        private static List<Operation> _operations = new List<Operation>()
        {
            new Operation()
            {
                Id = Guid.Parse("CDA7BDE0-AD48-13B8-6A76-184A02888278"),
                Name = "Основные средства"
            },
            new Operation()
            {
                Id = Guid.Parse("A146D9A5-28FA-B93D-C653-FBB63AE60116"),
                Name = "Кредитные обязательства"
            },
            new Operation()
            {
                Id = Guid.Parse("7811E126-15A2-B569-C8B2-54EC966CA4B2"),
                Name = "Дебиторская задолженность"
            },
            new Operation(){
                Id = Guid.Parse("AA152B71-D06A-1AB9-65CA-332773D2C01E"),
                Name = "Фонд заработной платы"
            },
            new Operation()
            {
                Id = Guid.Parse("57344AE9-478A-58BE-14B3-13209490FC6E"),
                Name = "Прочие активы"
            }
        };


        public void Add(Operation value)
        {
            _operations.Add(value);
        }

        public Operation GetItem(Guid id)
        {
            var result = _operations.FirstOrDefault(o => o.Id == id);
            return result;
        }

        public IEnumerable<Operation> GetList()
        {
            var result = _operations;
            return result;
        }

        public void Update(Operation value)
        {
            int index = _operations.IndexOf(_operations.FirstOrDefault(o => o.Id == value.Id));
            _operations[index] = value;
        }
    }
}
