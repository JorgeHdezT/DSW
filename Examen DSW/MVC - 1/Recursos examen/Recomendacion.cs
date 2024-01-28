using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ApellidoNombre_v1.Models
{
    [Table("Recomendacion")]
    public class Recomendacion
   
        {
            [Key]
            public int RecomendacionId { get; set; }

            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(160, ErrorMessage = "Solo se admiten 160 caracteres")]
            [DisplayName("Titulo")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Campo obligatorio")]
            [StringLength(320, ErrorMessage = "Solo se admiten 320 caracteres")]

            [DisplayName("Comentario")]
            public string Descripcion { get; set; }

            [Required(ErrorMessage = "Campo obligatorio")]
            [DisplayName("Estación")]
            [StringLength(10, ErrorMessage = "Solo se admiten 10 caracteres, solo puede ser primavera, verano, otoño, invierno")]
            public string Estacion { get; set; }

            [ForeignKey("CodigoProducto")]
            public int CodigoProducto { get; set; }
            public virtual Producto Producto { get; set; } = null!;
    }
    
    }

