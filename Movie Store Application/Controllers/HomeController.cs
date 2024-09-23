using Microsoft.AspNetCore.Mvc;

using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Movie_Store_Application.Repositories.Abstraction;
using Microsoft.AspNetCore.Cors;

namespace Movie_Store_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieServices _movieServices;
        public HomeController(IMovieServices movieServices)
        {
            this._movieServices = movieServices;
        }
        public ActionResult Index()
        {
            var result = _movieServices.List().ToList();
            return View(result);
        }
        public ActionResult About()
        {
            return View();
        }

    }
}
