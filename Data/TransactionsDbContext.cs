using ASP.NET_Core_Web_API.Models.Implementation;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API.Data
{
    public class TransactionsDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Operation> Operations { get; set; }

        public TransactionsDbContext(DbContextOptions<TransactionsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>().ToTable("Operation");
            modelBuilder.Entity<Transaction>().HasOne(transaction => transaction.Operation).
                WithMany(operation => operation.Transactions).HasForeignKey("OperationId");
        }
    }
}
