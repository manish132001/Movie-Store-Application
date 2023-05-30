using Microsoft.AspNetCore.Mvc;

namespace Movie_Store_Application.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
