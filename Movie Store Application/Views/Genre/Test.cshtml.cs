using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace Movie_Store_Application.Views.Genre
{
    public class TestModel : PageModel
    {
        public string Message { get; set; }   
        public void OnGet()
        {
            Message="this is MVVM pattern";
        }
    }
}
