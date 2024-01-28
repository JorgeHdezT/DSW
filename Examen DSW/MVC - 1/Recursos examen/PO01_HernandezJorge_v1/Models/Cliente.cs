using System;
using System.Collections.Generic;

namespace PO01_HernandezJorge_v1.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pagos = new HashSet<Pago>();
        }

        public int CodigoCliente { get; set; }
        public string NombreCliente { get; set; } = null!;
        public string? NombreContacto { get; set; }
        public string? ApellidoContacto { get; set; }
        public string Telefono { get; set; } = null!;
        public string Fax { get; set; } = null!;
        public string LineaDireccion1 { get; set; } = null!;
        public string? LineaDireccion2 { get; set; }
        public string Ciudad { get; set; } = null!;
        public string? Region { get; set; }
        public string? Pais { get; set; }
        public string? CodigoPostal { get; set; }
        public int? CodigoEmpleadoRepVentas { get; set; }
        public decimal? LimiteCredito { get; set; }

        public virtual Empleado? CodigoEmpleadoRepVentasNavigation { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
