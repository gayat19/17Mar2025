using ClinicApp.Interfaces;
using ClinicApp.Models;
using ClinicApp.Services;

namespace ClinicAppTest
{
    public class DoctorServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RegisterDoctorPassTest()
        {
            //Arrange
            IDoctorAuthenticate doctorService = new DoctorService();
            Doctor doctor = new Doctor()
            {
                Id = 1,
                Name = "Dr. John",
                YearsOfExperience = 10,
                Specialization = "Cardiologist",
                ConsultingFee = 500
            };

            //Action
            var result = doctorService.RegisterDoctor(doctor);

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
        }


    }
}