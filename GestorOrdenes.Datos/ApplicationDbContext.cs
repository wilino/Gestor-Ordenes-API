using GestorOrdenes.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GestorOrdenes.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<DetalleOrden> DetallesOrden { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Producto>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Producto>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<Orden>()
                .HasKey(o => o.Id);
            modelBuilder.Entity<Orden>()
                .Property(o => o.Id)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<Orden>()
                .HasOne(o => o.Cliente)
                .WithMany(c => c.Ordenes)
                .HasForeignKey(o => o.ClienteId);


            modelBuilder.Entity<DetalleOrden>()
                .HasKey(d => d.Id);
            modelBuilder.Entity<DetalleOrden>()
                .Property(d => d.Id)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<DetalleOrden>()
                .HasOne(d => d.Orden)
                .WithMany(o => o.DetallesOrden)
                .HasForeignKey(d => d.OrdenId);


            modelBuilder.Entity<DetalleOrden>()
                .HasOne(d => d.Producto)
                .WithMany()
                .HasForeignKey(d => d.ProductoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

