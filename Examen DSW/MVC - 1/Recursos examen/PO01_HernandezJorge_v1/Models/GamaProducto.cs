using System;
using System.Collections.Generic;

namespace PO01_HernandezJorge_v1.Models
{
    public partial class GamaProducto
    {
        public GamaProducto()
        {
            Productos = new HashSet<Producto>();
        }

        public string Gama { get; set; } = null!;
        public string? DescripcionTexto { get; set; }
        public string? DescripcionHtml { get; set; }
        public string? Imagen { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
