using CustomerDomainService.Controller;
using CustomerDomainService.Repository;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using CustomerDomainService.IRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MS_SQL_URL"));
});

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomerController();
app.UseHttpsRedirection();

app.Run();

