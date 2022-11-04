using Storage;

namespace ASP.NET_Core_Web_API
{
    public class Balance : ISavedData
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public DateOnly Date { get; set; }
        public decimal НематериальныеСредства { get; set; }
        public decimal ОсновныеСредства { get; set; }
        public decimal КапитальныеВложения { get; set; }
        public decimal ЗапасыТМЦ { get; set; }
        public decimal ДебиторскаяЗадолженность { get; set; }
        public decimal ФинансовыеВложения { get; set; }
        public decimal ПрочиеВложения { get; set; }
        public decimal УставнойКапитал { get; set; }
        public decimal ФондыИРезервы { get; set; }
        public decimal Прибыль { get; set; }
        public decimal КредитыИЗаймы { get; set; }
        public decimal КредиторскаяЗадолженность { get; set; }
        public decimal РасчетыСПерсоналом { get; set; }
        public decimal ЗадолженностьПоНалогам { get; set; }
        public decimal ПрочиеОбязательства { get; set; }
    }
}
