using API_Papeleria.IServices;
using API_Papeleria.Services;
using Data;
using Logic.ILogic;
using Logic.Logic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductoServices, ProductoServices>();
builder.Services.AddScoped<IPedidoServices, PedidoServices>();
builder.Services.AddScoped<IClienteServices, ClienteServices>();

builder.Services.AddScoped<IProductoLogic, ProductoLogic>();
builder.Services.AddScoped<IPedidoLogic, PedidoLogic>();
builder.Services.AddScoped<IClienteLogic, ClienteLogic>();

builder.Services.AddDbContext<ServiceContext>(
        options => options.UseSqlServer("name=ConnectionStrings:ServiceContext"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
