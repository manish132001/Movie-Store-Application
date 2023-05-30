using Microsoft.AspNetCore.Identity;

namespace Movie_Store_Application.Models.Domain
{
    public class ApplicationUser:IdentityUser
    {
        public string? Name { get; set; }
    }
}
