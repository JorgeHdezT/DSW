using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PO01_HernandezJorge_v1.Models;

namespace PO01_HernandezJorge_v1.Data
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

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<GamaProducto> GamaProductos { get; set; } = null!;
        public virtual DbSet<Oficina> Oficinas { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=jardineria; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CodigoCliente)
                    .HasName("PK__cliente__4D182E8DAB758DD1");

                entity.ToTable("cliente");

                entity.Property(e => e.CodigoCliente)
                    .ValueGeneratedNever()
                    .HasColumnName("codigo_cliente");

                entity.Property(e => e.ApellidoContacto)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("apellido_contacto");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ciudad");

                entity.Property(e => e.CodigoEmpleadoRepVentas).HasColumnName("codigo_empleado_rep_ventas");

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codigo_postal");

                entity.Property(e => e.Fax)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("fax");

                entity.Property(e => e.LimiteCredito)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("limite_credito");

                entity.Property(e => e.LineaDireccion1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("linea_direccion1");

                entity.Property(e => e.LineaDireccion2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("linea_direccion2");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_cliente");

                entity.Property(e => e.NombreContacto)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre_contacto");

                entity.Property(e => e.Pais)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pais");

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("region");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.CodigoEmpleadoRepVentasNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.CodigoEmpleadoRepVentas)
                    .HasConstraintName("FK__cliente__codigo___38996AB5");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.CodigoEmpleado)
                    .HasName("PK__empleado__CDEF1DDEB0159E88");

                entity.ToTable("empleado");

                entity.Property(e => e.CodigoEmpleado)
                    .ValueGeneratedNever()
                    .HasColumnName("codigo_empleado");

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido1");

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido2");

                entity.Property(e => e.CodigoJefe).HasColumnName("codigo_jefe");

                entity.Property(e => e.CodigoOficina)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codigo_oficina");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Extension)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("extension");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Puesto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("puesto");

                entity.HasOne(d => d.CodigoJefeNavigation)
                    .WithMany(p => p.InverseCodigoJefeNavigation)
                    .HasForeignKey(d => d.CodigoJefe)
                    .HasConstraintName("FK__empleado__codigo__2C3393D0");

                entity.HasOne(d => d.CodigoOficinaNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.CodigoOficina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__empleado__codigo__2B3F6F97");
            });

            modelBuilder.Entity<GamaProducto>(entity =>
            {
                entity.HasKey(e => e.Gama)
                    .HasName("PK__gama_pro__4877EEE48A89D015");

                entity.ToTable("gama_producto");

                entity.Property(e => e.Gama)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gama");

                entity.Property(e => e.DescripcionHtml)
                    .IsUnicode(false)
                    .HasColumnName("descripcion_html");

                entity.Property(e => e.DescripcionTexto)
                    .IsUnicode(false)
                    .HasColumnName("descripcion_texto");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("imagen");
            });

            modelBuilder.Entity<Oficina>(entity =>
            {
                entity.HasKey(e => e.CodigoOficina)
                    .HasName("PK__oficina__754CF298E0F83AFA");

                entity.ToTable("oficina");

                entity.Property(e => e.CodigoOficina)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codigo_oficina");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ciudad");

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codigo_postal");

                entity.Property(e => e.LineaDireccion1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("linea_direccion1");

                entity.Property(e => e.LineaDireccion2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("linea_direccion2");

                entity.Property(e => e.Pais)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pais");

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("region");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => new { e.CodigoCliente, e.IdTransaccion })
                    .HasName("PK__pago__CCF58284472409C5");

                entity.ToTable("pago");

                entity.Property(e => e.CodigoCliente).HasColumnName("codigo_cliente");

                entity.Property(e => e.IdTransaccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id_transaccion");

                entity.Property(e => e.FechaPago)
                    .HasColumnType("date")
                    .HasColumnName("fecha_pago");

                entity.Property(e => e.FormaPago)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("forma_pago");

                entity.Property(e => e.Total)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.CodigoClienteNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.CodigoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pago__codigo_cli__403A8C7D");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodigoProducto)
                    .HasName("PK__producto__105107A95A963560");

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

                entity.HasOne(d => d.GamaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Gama)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__producto__gama__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
