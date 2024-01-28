using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gonzalez_Keliam_Musica.Models;

public partial class Artist
{
    public int ArtistId { get; set; }

    [DisplayName("Nombre")]
    [Required(ErrorMessage = "El nombre del artista es un campo requerido.")]
    public string? Name { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}
