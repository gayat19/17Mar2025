using ClinicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Interfaces
{
    public interface IAdminWork : ICommonAdmin
    {
        public bool AdminLogin(string username, string password);
        public bool ChangeDoctorStatus(int doctorId, DoctorStatus status);
      
    }
}
