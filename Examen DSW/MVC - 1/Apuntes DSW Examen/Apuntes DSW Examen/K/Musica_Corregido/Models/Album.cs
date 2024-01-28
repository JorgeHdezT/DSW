using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Musica_Corregido.Models;

public partial class Album
{
    [Key]
    public int AlbumId { get; set; }
    [Required]
    [StringLength(160)]
    [DisplayName("Título")]
    public string Title { get; set; }
    public int ArtistId { get; set; }

    [ForeignKey("ArtistId")]
    [InverseProperty("Album")]
    [DisplayName("Artista")]
    public virtual Artist Artist { get; set; }
    [InverseProperty("Album")]
    public virtual ICollection<Track> Track { get; set; }
}
