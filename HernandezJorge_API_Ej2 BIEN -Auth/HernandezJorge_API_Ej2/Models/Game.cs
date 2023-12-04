using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HernandezJorge_API_Ej2.Models
{
    public class Game
    {
        [Key]
        public int JuegoId { get; set; }
        public string Titulo { get; set; }
        public Genre? Genero { get; set; }

        [ForeignKey("Genre")]
        public int GeneroId { get; set; }
    }
}
