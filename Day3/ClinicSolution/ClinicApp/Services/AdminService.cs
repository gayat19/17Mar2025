using ClinicApp.Interfaces;
using ClinicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Services
{
   
    public class AdminService : ICommonAdmin
    {
        //This implementation is totally wrong. It should be implementing all the interface methods
        public bool AddDoctor(Doctor doctor)
        {
            return true;//mis-guided implementation
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return new List<Doctor>();
        }
    }
}
