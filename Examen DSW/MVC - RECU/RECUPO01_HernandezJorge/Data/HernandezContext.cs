using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RECUPO01_HernandezJorge.Models;

namespace RECUPO01_HernandezJorge.Data
{
    public partial class HernandezContext : DbContext
    {
        public HernandezContext()
        {
        }

        public HernandezContext(DbContextOptions<HernandezContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=jardineria; Trusted_Connection = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodigoProducto)
                    .HasName("PK__producto__105107A9906642F5");

                entity.ToTable("producto");

                entity.Property(e => e.CodigoProducto).HasColumnName("codigo_producto");

                entity.Property(e => e.CantidadEnStock).HasColumnName("cantidad_en_stock");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Dimensiones)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("dimensiones");

                entity.Property(e => e.Gama)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gama");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrecioProveedor)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("precio_proveedor");

                entity.Property(e => e.PrecioVenta)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("precio_venta");

                entity.Property(e => e.Proveedor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("proveedor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<RECUPO01_HernandezJorge.Models.Venta>? Venta { get; set; }
    }
}
