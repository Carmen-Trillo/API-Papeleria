using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ServiceContext: DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }
        public DbSet<ProductoItem> Productos { get; set; }
        public DbSet<PedidoItem> Pedidos { get; set; }
        public DbSet<UsuarioItem> Usuarios { get; set; }
        public DbSet<ClienteItem> Clientes { get; set; }
        public DbSet<TrabajadorItem> Trabajadores { get; set; }
        public DbSet<RolItem> Roles { get; set; }
        public DbSet<ClienteRolItem> ClientesRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductoItem>()
            .ToTable("Productos");

            builder.Entity<PedidoItem>()
            .ToTable("Pedidos")
            .HasOne<ProductoItem>()
            .WithMany()
            .HasForeignKey(o => o.ProductoId);

            builder.Entity<UsuarioItem>()
            .ToTable("Usuarios");

            builder.Entity<ClienteItem>()
            .ToTable("Clientes");

            builder.Entity<TrabajadorItem>()
            .ToTable("Trabajadores");

            builder.Entity<ClienteRolItem>()
            .ToTable("Roles");

            builder.Entity<RolItem>()
            .ToTable("ClientesRoles");
        }
    }
    public class ServiceContextFactory : IDesignTimeDbContextFactory<ServiceContext>
    {
        public ServiceContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false, true);
            var config = builder.Build();
            var connectionString = config.GetConnectionString("ServiceContext");
            var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ServiceContext"));

            return new ServiceContext(optionsBuilder.Options);
        }
    }
}

