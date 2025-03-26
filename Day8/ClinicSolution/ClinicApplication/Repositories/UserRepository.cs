using ClinicApplication.Contexts;
using ClinicApplication.Exceptions;
using ClinicApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicApplication.Repositories
{
    public class UserRepository : Repository<string, User>
    {
        public UserRepository(ClinicContext context) : base(context)
        {
        }
        public override async Task<User> Get(string key)
        {
            var user = await _clinicContext.Users.SingleOrDefaultAsync(u => u.Username == key);
            if(user == null)
                throw new EntityNotFoundException($"User with the {key} not present");
            return user;
        }

        public override async Task<IEnumerable<User>> GetAll()
        {
            var users = _clinicContext.Users;
            if (users.Count() == 0)
                throw new EntityCollectionEmptyException();
            return await users.ToListAsync();
        }
    }
}
