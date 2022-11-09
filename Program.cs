using ASP.NET_Core_Web_API.Data;
using ASP.NET_Core_Web_API.Data.Implementation;
using ASP.NET_Core_Web_API.Data.Interfaces;
using ASP.NET_Core_Web_API.Domain.Implementation;
using ASP.NET_Core_Web_API.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


string connectionString = "Data Source=.; User Id=Storage; Password=123;";


//string connectionString = "workstation id=Storage.mssql.somee.com; packet size=4096; user id=repo; pwd=123456789; data source=Storage.mssql.somee.com; persist security info=False; initial catalog=Storage";



builder.Services.AddDbContext<StorageDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IOperationsRepo, OperationsRepo>();
builder.Services.AddScoped<ITransactionsRepo, TransactionsRepo>();
builder.Services.AddScoped<IOperationManager, OperationManager>();
builder.Services.AddScoped<ITransactionManager, TransactionManager>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
