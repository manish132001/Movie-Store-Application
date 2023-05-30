using Microsoft.EntityFrameworkCore.Metadata.Internal;

using Movie_Store_Application.Models.Domain;
using Movie_Store_Application.Repositories.Abstraction;

namespace Movie_Store_Application.Repositories.Implementation
{
    public class GenreServices:IGenreServices
    {
        private readonly DatabaseContext ctx;
        public GenreServices(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Genre model)
        {
            try
            {
                ctx.Genre.Add(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return false;
                ctx.Genre.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Genre GetById(int id)
        {
           

            return ctx.Genre.Find(id);
        }

        public IQueryable<Genre> List()
        {
            var data = ctx.Genre.AsQueryable();
            return data;
        }

        public bool Update(Genre model)
        {
            try
            {
                ctx.Genre.Update(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
