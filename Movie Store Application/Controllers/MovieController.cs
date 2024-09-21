using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movie_Store_Application.Models.Domain;
using Movie_Store_Application.Repositories.Abstraction;

namespace Movie_Store_Application.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieServices _movieservice;
        private readonly IGenreServices _genreservice;
        public MovieController(IMovieServices movieServices, IGenreServices genreServices)
        {
            _genreservice = genreServices;
            _movieservice = movieServices;
        }
        public IActionResult Add()
        {
            var model = new Movie();
            model.GenreList = _genreservice.List().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString() });
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(Movie model)
        {
            var result = _movieservice.Add(model);
            if(result == 1)
            {
                TempData["msg"] = "Movie Stored Successfully.";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error occurred.";
                return View(model);
            }
        }
        public IActionResult MovieList()
        {
            var data = _movieservice.List().ToList();
            return View(data);
        }
    }
}
