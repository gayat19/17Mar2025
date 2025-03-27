using ClinicApplication.Contexts;
using ClinicApplication.Exceptions;
using ClinicApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicApplication.Repositories
{
    public class AppointmentRepository :Repository<int, Appointment>
    {
        public AppointmentRepository(ClinicContext clinicContext) : base(clinicContext)
        {

        }
        public async override Task<Appointment> Get(int key)
        {
            var appointment = await _clinicContext.Appointments.SingleOrDefaultAsync(a => a.Id == key);

            if (appointment == null)

                throw new EntityNotFoundException($"Appointment with the {key} not present");

            return appointment;
        }
        public override async Task<IEnumerable<Appointment>> GetAll()
        {

            var appointment = _clinicContext.Appointments;

            if (appointment.Count() == 0)

                throw new EntityCollectionEmptyException();

            return await appointment.ToListAsync();
        }
    }

}

 