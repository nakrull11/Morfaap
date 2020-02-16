using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<PedidoModel> Pedido { get; set; }
        public DbSet<PlatoModel> Plato { get; set; }
        public DbSet<LocalModel> Local { get; set; }
        public DbSet<MenuModel> Menu { get; set; }
        public DbSet<ComentarioModel> Comentario { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComentarioModel>()
                .HasKey(o => new { o.IdUsuario, o.IdLocal });
        }
        public DbSet<DetalleModel> Detalle { get; set; }



    }
}
