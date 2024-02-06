using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ServiciosPrueba2.Models
{
    public partial class PruebaContext : DbContext
    {
        public PruebaContext()
        {
        }

        public PruebaContext(DbContextOptions<PruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Venta> Ventas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproductos)
                    .HasName("PK__Producto__D6304974FFED429C");

                entity.Property(e => e.Idproductos).HasColumnName("IDProductos");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.Idventas)
                    .HasName("PK__Ventas__A1991031ED10D4DB");

                entity.Property(e => e.Idventas).HasColumnName("IDVentas");

                entity.Property(e => e.Idproductos).HasColumnName("IDProductos");

                entity.HasOne(d => d.IdproductosNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Idproductos)
                    .HasConstraintName("FK__Ventas__IDProduc__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
