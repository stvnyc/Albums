using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albums.Data.Models;

public class Album
{
    [Key]
    public int AlbumId { get; set; }
    [Required(ErrorMessage = "The album title is required")]
    public string? AlbumTitle { get; set; }
    [Required(ErrorMessage = "The artist name is required")]
    public string? ArtistName { get; set; }
    [Required(ErrorMessage = "The song number is required")]
    public int? SongNumber { get; set; }
    [Required(ErrorMessage = "The release year is required")]
    public int? ReleaseYear { get; set; }
    [Required(ErrorMessage = "The genre is required")]
    [ForeignKey("GenreId")]
    public int GenreId { get; set; }
}
