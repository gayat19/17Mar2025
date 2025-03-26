using ClinicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Interfaces
{
    public interface IDoctorAuthenticate
    {
        public Doctor RegisterDoctor(Doctor doctor);
        public Doctor Login(int doctorId, string password);

    }
}
