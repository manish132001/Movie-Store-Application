using Microsoft.AspNetCore.Mvc;
using Movie_Store_Application.Shared;
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
        private GetList getList;
        public HomeController(IMovieServices movieServices)
        {
            getList = GetList.Instance();
            this._movieServices = movieServices;
        }
        public ActionResult Index()
        {
            var result = _movieServices.List().ToList();
            return View(result);
        }
        public ActionResult About()
        {
            ViewBag.res = getList.text;
            return View();
        }

    }
}
