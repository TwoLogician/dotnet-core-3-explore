using System;
using System.ComponentModel.DataAnnotations;

namespace HelloDotNet3.Models
{
    public class MovieInfo
    {
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}