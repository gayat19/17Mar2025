using ClinicApplication.Exceptions;
using ClinicApplication.Interfaces;
using ClinicApplication.Models;
using ClinicApplication.Models.ViewModels;
using ClinicApplication.Repositories;

namespace ClinicApplication.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<int, Doctor> _doctorRepository;
        private readonly IRepository<string, User> _userRepository;

        public DoctorService(IRepository<int,Doctor> doctorRepository, 
            IRepository<string,User> userRepository)
        {
            _doctorRepository = doctorRepository;
            _userRepository = userRepository;
        }
        public async Task<bool> RegisterDoctor(UserDoctor userDoctor)
        {
            try
            {
                
                try
                {
                    var isEmailRegistered = await GetDoctorByUsernameAsync(userDoctor.Email);
                    if (isEmailRegistered)
                        throw new UserEmailDuplicateException($"Email - {userDoctor.Email} already registered");
                }
                catch (EntityNotFoundException e)
                {

                }
                Doctor doctor = await MapUserDoctorToDoctor(userDoctor);
                User user = await MapUserDoctorToUser(userDoctor);
                var userResult = await _userRepository.Add(user);
                var doctorResult = await _doctorRepository.Add(doctor);
                return true;
            }
            catch (EntityNotFoundException e)
            {
                return false;
            }
            
        }

        private async Task<User> MapUserDoctorToUser(UserDoctor userDoctor)
        {
            User user = new User
            {
                Username = userDoctor.Email,
                Password = userDoctor.Password,
                Role = "Doctor"
            };
            return user;
        }

        private async Task<Doctor> MapUserDoctorToDoctor(UserDoctor userDoctor)
        {
           Doctor doctor = new Doctor
           {
               Name = userDoctor.Name,
               Phone = userDoctor.Phone,
               Email = userDoctor.Email
           };   
            return doctor;
        }

        private async Task<bool> GetDoctorByUsernameAsync(string email)
        {
        
            return await _userRepository.Get(email) != null;
        }
    }
}
