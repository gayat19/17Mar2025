

using ClinicApplication.Contexts;
using ClinicApplication.Interfaces;
using ClinicApplication.Models;
using ClinicApplication.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicTestng
{
    public class DoctorRepositoryTest
    {
        IRepository<int,Doctor> _doctorRepository;
        IRepository<string, User> _userRepository;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<ClinicContext> options = new DbContextOptionsBuilder<ClinicContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            ClinicContext clinicContext = new ClinicContext(options);
            _doctorRepository = new DoctorRepository(clinicContext);
            _userRepository = new UserRepository(clinicContext);
        }

        [Test]
        public async Task AddDoctorPassTestAsync()
        {
            //Arrange
            User user = new User
            {
                Username = "test@test.test",
                Password = "Test",
                Role = "Doctor"
            };
            await _userRepository.Add(user);
            Doctor doctor = new Doctor
            {
                Name = "Test",
                Email = user.Username,
                Phone = "1234567890",
            };
            //Action
            var result = await _doctorRepository.Add(doctor);
            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
        }
    }
}