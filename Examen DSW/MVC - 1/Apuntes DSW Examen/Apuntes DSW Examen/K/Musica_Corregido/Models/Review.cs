using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Musica_Corregido.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(160, ErrorMessage = "Solo se admiten 160 caracteres")]
        [DisplayName("Título")]
        public string Title { get; set; }

        [StringLength(320, ErrorMessage = "Solo se admiten 320 caracteres")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [DisplayName("Comentario")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [DisplayName("Puntuacion")]
        [Range(1, 5, ErrorMessage = "Solo se admiten valores enteros entre 1 y 5")]
        public int Rating { get; set; }

        [ForeignKey("ArtistId")]
        public int ArtistId { get; set; }

        [DisplayName("Artista")]
        public virtual Artist Artist { get; set; }

    }
}
