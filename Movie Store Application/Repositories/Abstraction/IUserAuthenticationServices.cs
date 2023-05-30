using Movie_Store_Application.Models.DTO;

namespace Movie_Store_Application.Repositories.Abstraction
{
    public interface IUserAuthenticationServices
    {
        Task<Status> LoginAsync(Login model);
        Task LogoutAsync();
        Task<Status> RegistrationAsync(Registration model);
    }
}
