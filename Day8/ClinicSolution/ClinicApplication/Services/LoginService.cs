using ClinicApplication.Interfaces;
using ClinicApplication.Models;
using ClinicApplication.Models.ViewModels;
using ClinicApplication.Repositories;
using ClinicApplication.Exceptions;

namespace ClinicApplication.Services
{
    public class LoginService : IAuthenticationService
    {
        private readonly IRepository<int, Doctor> _doctorRepository;
        private readonly IRepository<string, Patient> _patientRepository;
        private readonly IRepository<string, User> _userRepository;

        public LoginService(IRepository<int, Doctor> doctorRepository,
                            IRepository<string, Patient> patientRepository,
                            IRepository<string, User> userRepository)
        {
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _userRepository = userRepository;
        }
        public async Task<LoginResponse> Login(LoginUser user)
        {
            try
            {
                var dbUser = await _userRepository.Get(user.Username);
                if (dbUser == null)
                {
                    throw new UnAuthorizedException("Invalid Username or Password");
                }
                if(dbUser.Password != user.Password)
                {
                    throw new UnAuthorizedException("Invalid Username or Password");
                }
                if (dbUser.Role == "Doctor")
                {
                    Doctor doctor = await GetDoctorName(dbUser.Username);
                    return new LoginResponse { Name = doctor.Name, Role = dbUser.Role };
                }
                else if (dbUser.Role == "Patient")
                {
                    Patient patient = await GetPatientName(dbUser.Username);
                    return new LoginResponse { Name = patient.Name, Role = dbUser.Role };
                }
                throw new UnAuthorizedException("Invalid Username or Password");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<Patient> GetPatientName(string username)
        {
            var patient = (await _patientRepository.GetAll()).FirstOrDefault(p => p.Email == username);
            return patient;
        }

        private async Task<Doctor> GetDoctorName(string username)
        {
            var doctor = (await _doctorRepository.GetAll()).FirstOrDefault(d => d.Email == username);
            return doctor;
        }
    }
}
