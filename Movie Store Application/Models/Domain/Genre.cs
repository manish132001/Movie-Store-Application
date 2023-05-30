using Microsoft.Build.Framework;

namespace Movie_Store_Application.Models.Domain
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string? GenreName { get; set; }
    }
}
