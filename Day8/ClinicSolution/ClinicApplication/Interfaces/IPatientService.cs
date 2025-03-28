using ClinicApplication.Migrations;
using ClinicApplication.Models;
using ClinicApplication.Models.ViewModels;

namespace ClinicApplication.Interfaces
{
    public interface IPatientService
    {
        Task<Patient> Register(UserPatient patient);
    }
}
