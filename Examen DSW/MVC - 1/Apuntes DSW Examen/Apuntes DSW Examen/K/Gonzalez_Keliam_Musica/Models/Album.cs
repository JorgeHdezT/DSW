using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gonzalez_Keliam_Musica.Models;

public partial class Album
{
    public int AlbumId { get; set; }

    [DisplayName("Título")]
    [Required(ErrorMessage = "El Título es un campo requerido.")]
 
    public string Title { get; set; } = null!;

    public int ArtistId { get; set; }

    [DisplayName("Artista")]
    [Required(ErrorMessage = "Seleccione un Artista.")]

    public virtual Artist Artist { get; set; } = null!;

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
