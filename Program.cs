using System.Collections.Immutable;
using ASP.NET_Core_Web_API.Data;
using ASP.NET_Core_Web_API.Data.Implementation;
using ASP.NET_Core_Web_API.Data.Interfaces;
using ASP.NET_Core_Web_API.Domain.Implementation;
using ASP.NET_Core_Web_API.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration["DatabaseOptions:ConnectionStrings:SQL"];

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
