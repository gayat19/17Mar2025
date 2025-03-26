using ClinicApplication.Contexts;
using ClinicApplication.Exceptions;
using ClinicApplication.Interfaces;
using ClinicApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ClinicApplication.Repositories
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly ClinicContext _context;//Readonly makes it more faster for access

        public DoctorRepository(ClinicContext context)
        {
            _context = context;
        }
        public async Task<Doctor> Add(Doctor entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Doctors.Add(entity);//will add the entity to collection and set its state to added
            //added state entry will lead to generation of insert query while we save changes
            await _context.SaveChangesAsync();//Will execute the insert query and change the state of the entry to unchanged
            return entity;
        }

        public async Task<Doctor> Delete(int key)
        {
            var doctor = await Get(key);
           if (doctor == null)
                throw new EntityNotFoundException($"Doctor with the {key} not present");
            _context.Doctors.Remove(doctor);//Change the state of the entity to deleted
            await _context.SaveChangesAsync();//Generate the delete query and execute it
            return doctor;
        }

        public async Task<Doctor> Get(int key)
        {   
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == key);
            if(doctor == null)
                throw new EntityNotFoundException($"Doctor with the {key} not present");
            return doctor;
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            var doctors =  _context.Doctors;
            if (doctors.Count() == 0)
                throw new EntityCollectionEmptyException();
            return doctors;
        }

        public async Task<Doctor> Update(int key,Doctor entity)
        {
            var doctor = await Get(key);
            if (doctor == null)
                throw new EntityNotFoundException($"Doctor with the {entity.Id} not present");
            _context.Entry(doctor).CurrentValues.SetValues(entity);//Update the values of the entity
            //The above code will do Property by property mapping like bellow
            //doctor.Id = entity.Id;
            //doctor.Name = entity.Name;
            //doctor.Email = entity.Email;
            await _context.SaveChangesAsync();
            return doctor;

        }
    }
}
