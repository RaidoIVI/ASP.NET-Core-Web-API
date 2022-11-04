namespace Storage
{
    public interface ISavedData
    {
        int ID { get; set; }
        string CompanyName { get; set; }
        DateOnly Date { get; set; }
        decimal НематериальныеСредства { get; set; }
        decimal ОсновныеСредства { get; set; }
        decimal КапитальныеВложения { get; set; }
        decimal ЗапасыТМЦ { get; set; }
        decimal ДебиторскаяЗадолженность { get; set; }
        decimal ФинансовыеВложения { get; set; }
        decimal ПрочиеВложения { get; set; }
        decimal УставнойКапитал { get; set; }
        decimal ФондыИРезервы { get; set; }
        decimal Прибыль { get; set; }
        decimal КредитыИЗаймы { get; set; }
        decimal КредиторскаяЗадолженность { get; set; }
        decimal РасчетыСПерсоналом { get; set; }
        decimal ЗадолженностьПоНалогам { get; set; }
        decimal ПрочиеОбязательства { get; set; }
    }
}