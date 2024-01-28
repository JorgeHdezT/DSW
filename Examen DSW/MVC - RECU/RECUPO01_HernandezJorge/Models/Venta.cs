using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace RECUPO01_HernandezJorge.Models
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "El numero de productos a vender es entre 1 y 10")]
        [DisplayName("Unidades")]
        public int Units { get; set; }
        [Required]
        public int productoId { get; set; }
        public Producto? producto { get; set; }
        public string? ComercialId { get; set; }
    }
}


// Scaffold-DBContext "Server=(localdb)\MSSQLLocalDB; Database=jardineria; Trusted_Connection = True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models - Tables producto -ContextDir Data -f





