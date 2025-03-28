using ClinicApplication.Exceptions;
using ClinicApplication.Interfaces;
using ClinicApplication.Misc;
using ClinicApplication.Models;
using ClinicApplication.Models.ViewModels;
using ClinicApplication.Repositories;

namespace ClinicApplication.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<string, Patient> _patientRepository;
        private readonly IRepository<string, User> _userRepository;
        private readonly PatientIDGenerator _iDGenerator;

        public PatientService(IRepository<string,Patient> patientRepository,
                              IRepository<string,User> userRepository,
                              PatientIDGenerator iDGenerator)
        {
            _patientRepository = patientRepository;
            _userRepository = userRepository;
            _iDGenerator = iDGenerator;
        }
        public async Task<Patient> Register(UserPatient patient)
        {
            try
            {
                User user = await MapUserPatientToUser(patient);
                var userResult = await _userRepository.Add(user);
                if (userResult != null)
                {
                    Patient dbPatient = await MapUserPatientToPatinet(patient);
                    var result = await _patientRepository.Add(dbPatient);
                    return result;
                }
                throw new Exception("Unable to create user");
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private async Task<Patient> MapUserPatientToPatinet(UserPatient patient)
        {
            var patientID = await _iDGenerator.GeneratePatientID();
            return new Patient
            {
                PatientNumber = patientID,
                Name = patient.Name,
                Email = patient.Email,
                Phone = patient.Phone,
                Age = patient.Age,
            };
        }

        private async Task<User> MapUserPatientToUser(UserPatient patient)
        {
            User user;
            try
            {
                 user = await _userRepository.Get(patient.Email);
                if (user != null)
                {
                    throw new UserEmailDuplicateException($"Email - {patient.Email} already registered");
                }
            }
            catch (EntityNotFoundException e)
            {
            }
            user = new User
            {
                Username = patient.Email,
                Password = patient.Password,
                Role = "Patient"
            };
            return user;
        }
    }
}
