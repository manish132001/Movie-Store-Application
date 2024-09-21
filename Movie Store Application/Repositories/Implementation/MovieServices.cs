using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using Movie_Store_Application.Models.Domain;
using Movie_Store_Application.Repositories.Abstraction;

namespace Movie_Store_Application.Repositories.Implementation
{
    public class MovieServices:IMovieServices
    {
        private readonly DatabaseContext ctx;
        public MovieServices(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public int Add(Movie model)
        {
            try
            {
                ctx.Movie.Add(model);
                ctx.SaveChanges();
                return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
            
        }

        public List<Movie> List() {
            

            var genres = (from movie in ctx.Movie
                          join genre in ctx.Genre
                          on movie.GenreId equals genre.Id into MovieGenre
                          from genre in MovieGenre.DefaultIfEmpty()
                          select new Movie                                   
                          {
                              Id = movie.Id,
                              Title = movie.Title,
                              ReleaseYear = movie.ReleaseYear,
                              GenreId = movie.GenreId,
                              Director = movie.Director,
                              GenreNames = genre != null ? genre.GenreName : null, 
                              Cast = movie.Cast
                          }).ToList();

            //var res= ctx.Movie.ToList();
            return genres;
        }
    }
}
