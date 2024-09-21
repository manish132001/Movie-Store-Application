namespace Movie_Store_Application.Models.DTO
{
    public class MovieGenre
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? ReleaseYear { get; set; }
        public string? MovieImage { get; set; }
        public string? Cast { get; set; }
        public string? Director { get; set; }
        public string? GenreName { get; set; }
        public int? GenreId { get; set; }
    }
}
