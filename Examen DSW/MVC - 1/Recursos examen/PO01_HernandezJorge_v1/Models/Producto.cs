using System;
using System.Collections.Generic;

namespace PO01_HernandezJorge_v1.Models
{
    public partial class Producto
    {
        public int CodigoProducto { get; set; }
        public string Nombre { get; set; } = null!;
        public string Gama { get; set; } = null!;
        public string? Dimensiones { get; set; }
        public string? Proveedor { get; set; }
        public string? Descripcion { get; set; }
        public short CantidadEnStock { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal? PrecioProveedor { get; set; }

        public virtual GamaProducto GamaNavigation { get; set; } = null!;
    }
}
