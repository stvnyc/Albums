using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albums.Data.Models;

public class Genre
{
    [Key]
    public int GenreId { get; set; }
    [Required(ErrorMessage = "The genre name is requied")]
    public string? GenreName { get; set; }
}
