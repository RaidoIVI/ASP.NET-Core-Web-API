using Microsoft.EntityFrameworkCore;


namespace Storage
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<>? { get; set; } // Добавить тип, подумать об абстакции
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    {
        if (!optionsBuilder.IsConfigured)
        {
            string connect = "workstation id=Storage.mssql.somee.com;packet size=4096;user id=Storage;pwd=tRg81zFpn;data source=Storage.mssql.somee.com;persist security info=False;initial catalog=Storage";
            optionsBuilder.UseSqlServer(connect);
            return;
        }
    }
}
}
