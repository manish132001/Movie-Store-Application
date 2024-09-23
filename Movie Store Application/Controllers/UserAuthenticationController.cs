using Microsoft.AspNetCore.Mvc;

using Movie_Store_Application.Models.DTO;
using Movie_Store_Application.Repositories.Abstraction;

using NuGet.DependencyResolver;

namespace Movie_Store_Application.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationServices authservices;
        public UserAuthenticationController(IUserAuthenticationServices authservices)
        {
            this.authservices = authservices;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Registration model)
        {
            
            var result = await authservices.RegistrationAsync(model);
            return Ok(result.Message);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await authservices.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                //HttpContext.Session.SetString("Username", model.Username); 
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = "Could not logged in..";
                return RedirectToAction(nameof(Login));
            }
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await authservices.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
