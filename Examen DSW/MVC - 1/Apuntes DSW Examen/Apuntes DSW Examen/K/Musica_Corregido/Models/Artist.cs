using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Musica_Corregido.Models;

public partial class Artist
{
    [Key]
    public int ArtistId { get; set; }
    [StringLength(120)]
    public string Name { get; set; }

    [InverseProperty("Artist")]
    public virtual ICollection<Album> Album { get; set; } = new List<Album>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
