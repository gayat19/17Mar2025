using ClinicApp.Exceptions;
using ClinicApp.Interfaces;
using ClinicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Services
{
    public class DoctorService : IDoctorAuthenticate, IAdminWork
    {
        List<Doctor> doctors = new List<Doctor>();

        public bool AdminLogin(string username, string password)
        {
           if(username.ToLower() == "admin" && password.ToLower() == "admin")
            {
                return true;
            }
            return false;
        }

        public bool ChangeDoctorStatus(int doctorId, DoctorStatus status)
        {
            if(doctors.Count == 0)
            {
                throw new CollectionEmptyException("No doctors are available in the system");
            }
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Id == doctorId)
                {
                    if(doctors[i].Status == status)
                    {
                        throw new InvalidOperationException("Doctor is already in the given status");
                    }
                    doctors[i].Status = status;
                    return true;
                }
            }
            throw new NoSuchEntityException("Doctor with the given Id is not available in the system");
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            if(doctors.Count == 0)
            {
                throw new CollectionEmptyException("No doctors are available in the system");
            }
            return doctors;
        }

        public Doctor? Login(int doctorId, string password)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Id == doctorId && doctors[i].Password == password)
                {
                    return doctors[i];
                }
            }
            return null;
        }

        public virtual Doctor RegisterDoctor(Doctor doctor)
        {
            doctor.Id = GenerateId();
           // doctor.TakeDoctorDetailsFromConsole();
            doctor.Password = doctor.Name + doctor.Id;
            doctors.Add(doctor);//adding the doctor object to the collection
            string value = $"Registration Successful!! \nYour username is your Id({doctor.Id})\nYour password is Your name followed by your Id which is  {doctor.Id}";
            Console.WriteLine(value);
            return doctor;
        }

        private int GenerateId()
        {
            if(doctors.Count == 0)
            {
                return 1;
            }
            int maxId = 0;
            foreach (var doctor in doctors)
            {
                if (doctor.Id > maxId)
                {
                    maxId = doctor.Id;
                }
            }
            return maxId + 1;
        }
    }
}
