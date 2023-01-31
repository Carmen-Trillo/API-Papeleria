using Data;
using Logic.ILogic;
using Logic.Logic;
using Microsoft.EntityFrameworkCore;
using API_Papeleria.IServices;
using API_Papeleria.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductoServices, ProductoServices>();
builder.Services.AddScoped<IPedidoServices, PedidoServices>();
builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
builder.Services.AddScoped<ISecurityServices, SecurityServices>();
builder.Services.AddScoped<IPersonaServices, PersonaServices>();
builder.Services.AddScoped<IRolServices, RolServices>();
//builder.Services.AddScoped<ITrabajadorServices, TrabajadorServices>();
//builder.Services.AddScoped<ITipoClienteServices, TipoClienteServices>();*/

builder.Services.AddScoped<IProductoLogic, ProductoLogic>();
builder.Services.AddScoped<IPedidoLogic, PedidoLogic>();
builder.Services.AddScoped<IUsuarioLogic, UsuarioLogic>();
builder.Services.AddScoped<ISecurityLogic, SecurityLogic>();
builder.Services.AddScoped<IPersonaLogic, PersonaLogic>();
builder.Services.AddScoped<IRolLogic, RolLogic>();
//builder.Services.AddScoped<ITrabajadorLogic, TrabajadorLogic>();
//builder.Services.AddScoped<ITipoCliente, TipoClienteLogic>();*/

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
