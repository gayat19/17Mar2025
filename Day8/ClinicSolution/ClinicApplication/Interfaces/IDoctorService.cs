using ClinicApplication.Models.ViewModels;

namespace ClinicApplication.Interfaces
{
    public interface IDoctorService
    {
        Task<bool> RegisterDoctor(UserDoctor userDoctor);
    }
}
