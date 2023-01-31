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
        public DbSet<PersonaItem> Personas { get; set; }
        public DbSet<UsuarioItem> Usuarios { get; set; }
        public DbSet<ClienteItem> Clientes { get; set; }
        public DbSet<RolItem> Roles { get; set; }
        public DbSet<TipoClienteItem> TiposClientes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductoItem>()
            .ToTable("Productos");

            builder.Entity<PedidoItem>(pedido =>
            {
                pedido.ToTable("Pedidos");
                pedido.HasOne<ProductoItem>().WithMany().HasForeignKey(p => p.IdProducto);
                pedido.HasOne<ClienteItem>().WithMany().HasForeignKey(p => p.IdCliente);
            });

            builder.Entity<PersonaItem>()
            .ToTable("Personas");

            builder.Entity<UsuarioItem>(usuario =>
            {
                usuario.ToTable("Usuarios");
                usuario.HasOne<PersonaItem>().WithMany().HasForeignKey(u => u.IdPersona);
                usuario.HasIndex(c => c.IdPersona).IsUnique();
                usuario.HasOne<RolItem>().WithMany().HasForeignKey(u => u.IdRol);

            });

            builder.Entity<ClienteItem>(cliente =>
            {
                cliente.ToTable("Clientes");
                cliente.HasOne<PersonaItem>().WithMany().HasForeignKey(c => c.IdPersona);
                cliente.HasIndex(c => c.IdPersona).IsUnique();

                cliente.HasOne<RolItem>().WithMany().HasForeignKey(c => c.IdRol);
                cliente.HasOne<TipoClienteItem>().WithMany().HasForeignKey(c => c.IdTipoCliente);
            });

            builder.Entity<RolItem>()
            .ToTable("Roles");

            builder.Entity<TipoClienteItem>()
            .ToTable("TipoClientes");
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

