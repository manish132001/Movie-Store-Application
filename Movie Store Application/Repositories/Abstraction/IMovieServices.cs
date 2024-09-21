using Movie_Store_Application.Models.Domain;

namespace Movie_Store_Application.Repositories.Abstraction
{
    public interface IMovieServices
    {
        public int Add(Movie model);

        public List<Movie> List();
    }
}
