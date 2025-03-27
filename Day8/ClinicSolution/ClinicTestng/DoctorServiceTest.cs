
using ClinicApplication.Contexts;
using ClinicApplication.Exceptions;
using ClinicApplication.Interfaces;
using ClinicApplication.Models;
using ClinicApplication.Models.ViewModels;
using ClinicApplication.Repositories;
using ClinicApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace ClinicTestng
{
    public class DoctorServiceTest
    {
        IRepository<int, Doctor> _doctorRepository;
        IRepository<string, User> _userRepository;
        IDoctorService service;
        [SetUp]
        public void Setup()
        {
            DbContextOptions<ClinicContext> options = new DbContextOptionsBuilder<ClinicContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            ClinicContext clinicContext = new ClinicContext(options);
            _doctorRepository = new DoctorRepository(clinicContext);
            _userRepository = new UserRepository(clinicContext);
            service = new DoctorService(_doctorRepository, _userRepository);
        }
        [Test]
        public async Task UserAddPassTest()
        {
            //Arrange
            User user = new User
            {
                Username = "test@test.test",
                Password = "Test",
                Role = "Doctor"
            };
            Doctor doctor = new Doctor
            {
                Name = "Test",
                Email = user.Username,
                Phone = "1234567890",
            };
            UserDoctor userDoctor = new UserDoctor
            {
                Name = doctor.Name,
                Email = doctor.Email,
                Phone = doctor.Phone,
                Password = user.Password
            };
            //Action
            var result = await service.RegisterDoctor(userDoctor);
            //Assert
            Assert.That(result, Is.True);
        }
        [Test]
        public async Task UserAddExceptionTest()
        {
            //Arrange
            User user = new User
            {
                Username = "test@test.test",
                Password = "Test",
                Role = "Doctor"
            };
           
            User user1 = new User
            {
                Username = "test@test.test",
                Password = "Test",
                Role = "Doctor"
            };
            Doctor doctor = new Doctor
            {
                Name = "Test",
                Email = user.Username,
                Phone = "1234567890",
            };
            UserDoctor userDoctor = new UserDoctor
            {
                Name = doctor.Name,
                Email = doctor.Email,
                Phone = doctor.Phone,
                Password = user.Password
            };
            //Action
            var result = await _userRepository.Add(user);
            //Assert
            Assert.ThrowsAsync<UserEmailDuplicateException>(async () => await service.RegisterDoctor(userDoctor));
        }
    }
}
