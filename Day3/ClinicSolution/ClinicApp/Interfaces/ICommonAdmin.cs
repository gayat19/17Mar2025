using ClinicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Interfaces
{
    public  interface ICommonAdmin
    {
        public IEnumerable<Doctor> GetDoctors();
    }
}
