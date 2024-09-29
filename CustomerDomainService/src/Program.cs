using CustomerDomainService.Controller;
using CustomerDomainService.Repository;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using CustomerDomainService.IRepository;
using FluentValidation;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.UseHttpClientMetrics();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MS_SQL_URL"));
});

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssemblyContaining<AddCustomerCommandValidator>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingPipelineBehavior<,>));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMetricServer();
app.UseHttpMetrics();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseCustomerController();
app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.MapGet("", () => "test prometheus");

app.Run();
