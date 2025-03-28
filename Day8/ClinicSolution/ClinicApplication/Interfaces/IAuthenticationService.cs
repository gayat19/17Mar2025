using ClinicApplication.Models;
using ClinicApplication.Models.ViewModels;

namespace ClinicApplication.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> Login(LoginUser user);
    }
}
