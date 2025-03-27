using ClinicApplication.Contexts;
using ClinicApplication.Exceptions;
using ClinicApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicApplication.Repositories
{
    public class PatientRepository : Repository<string, Patient>
    {
        public PatientRepository(ClinicContext context) : base(context)
        {
        }
        public async override Task<Patient> Get(string key)
        {
           var patient = await _clinicContext.Patients.SingleOrDefaultAsync(p => p.PatientNumber == key);
            if (patient == null)
                throw new EntityNotFoundException($"Patient with the {key} not present");
            return patient;
        }

        public async override Task<IEnumerable<Patient>> GetAll()
        {
           var patients = _clinicContext.Patients;
            if (patients.Count() == 0)
                throw new EntityCollectionEmptyException();
            return patients;
        }
    }
}
