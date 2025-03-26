using ClinicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Services
{
    public class DoctorServiceV1 : DoctorService
    {
        public void NewFunctionalities()
        {
            Console.WriteLine("New functionalities added");
        }
        public override Doctor RegisterDoctor(Doctor doctor)
        {
            Console.WriteLine("New functionalities");
            return base.RegisterDoctor(doctor);
        }
    }
}
