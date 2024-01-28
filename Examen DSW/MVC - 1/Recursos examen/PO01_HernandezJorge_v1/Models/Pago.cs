using System;
using System.Collections.Generic;

namespace PO01_HernandezJorge_v1.Models
{
    public partial class Pago
    {
        public int CodigoCliente { get; set; }
        public string FormaPago { get; set; } = null!;
        public string IdTransaccion { get; set; } = null!;
        public DateTime FechaPago { get; set; }
        public decimal Total { get; set; }

        public virtual Cliente CodigoClienteNavigation { get; set; } = null!;
    }
}
