using Microsoft.AspNetCore.Mvc;

using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Movie_Store_Application.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        
    

}
}
