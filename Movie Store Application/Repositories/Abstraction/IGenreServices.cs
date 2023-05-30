using Movie_Store_Application.Models.Domain;

namespace Movie_Store_Application.Repositories.Abstraction
{
    public interface IGenreServices
    {
        bool Add(Genre model);
        bool Update(Genre model);
        Genre GetById(int id);
        bool Delete(int id);
        IQueryable<Genre> List();
    }
}
