using ClinicApplication.Contexts;
using ClinicApplication.Exceptions;
using ClinicApplication.Interfaces;

namespace ClinicApplication.Repositories
{
    public abstract class Repository<K,T> : IRepository<K, T> where T : class
    {
        protected readonly ClinicContext _clinicContext;
        public Repository(ClinicContext clinicContext) {
            _clinicContext = clinicContext;
        }
        public abstract Task<IEnumerable<T>> GetAll();


        public abstract Task<T> Get(K key);
        

        public async Task<T> Add(T entity)
        {
            _clinicContext.Add(entity);
            await _clinicContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(K key,T entity)
        {
            var data = await Get(key);
            if (data == null)
                throw new EntityNotFoundException($"Entity with the {key} not present");
            _clinicContext.Entry(data).CurrentValues.SetValues(entity);
            await _clinicContext.SaveChangesAsync();
            return data;
        }

        public async Task<T> Delete(K key)
        {
            var data = await Get(key);
            if (data == null)
                throw new EntityNotFoundException($"Entity with the {key} not present");
            _clinicContext.Remove(data);
            await _clinicContext.SaveChangesAsync();
            return data;
        }
    }

}
