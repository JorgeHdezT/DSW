using System.ComponentModel.DataAnnotations;

namespace HernandezJorge_API_Ej2.Models
{
    public class Genre
    {
        [Key]
        public int GeneroId { get; set; }
        public string Nombre { get; set; }
        public List<Game>? Juegos { get; set; }
    }
}
