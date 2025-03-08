using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess
{
    public class UserRepository
    {
        protected readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IList<User> GetAll()
        {
            return _appDbContext.Set<User>().AsQueryable<User>().ToList();
        }

        public User? Get(Func<User, bool> filter)
        {
            return _appDbContext.Set<User>().FirstOrDefault(filter);
        }

        public void Add(User user)
        {
            try
            {
                _appDbContext.Set<User>().Add(user);
                _appDbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException(e.Message);
            }
        }

        public void Delete(User user)
        {
            try
            {
                _appDbContext.Set<User>().Remove(user);
                _appDbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException(e.Message);
            }
        }
    }
}
