using ClinicApp.Exceptions;
using ClinicApp.Interfaces;
using ClinicApp.Models;
using ClinicApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppTest
{
    public class AdminServiceTest
    {
        IAdminWork adminWork;
        IDoctorAuthenticate doctorAuthenticate;
        [SetUp]
        public void Setup()
        {
            DoctorService doctorService = new DoctorService();
            adminWork = doctorService;
            doctorAuthenticate = doctorService;
        }
        [Test]
        public void AdminGetDoctorsPassTest()
        {
            //Arrange
            Doctor doctor = new Doctor()
            {
                Id = 1,
                Name = "Dr. John",
                YearsOfExperience = 10,
                Specialization = "Cardiologist",
                ConsultingFee = 500
            };
            doctorAuthenticate.RegisterDoctor(doctor);
            //Action
            var result = adminWork.GetDoctors();
            //Assert
            Assert.That(result.Count(), Is.EqualTo(1));
        }
        [Test]
        public void AdminGetExceptionTest()
        {
            //assert
            Assert.Throws<CollectionEmptyException>(() => adminWork.GetDoctors());
        }
    }
}
