using Domain;
using Services.DataAccess;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SessionService : ISessionService
    {
        private readonly InMemoryDatabase _inMemoryDatabase;

        public SessionService(InMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public UserDTO GetLoggedUser()
        {
            return LoggedUser.Current;
        }

        public void Login(string email, string password)
        {
            User? user = _inMemoryDatabase.Users.FirstOrDefault(user => user.Email == email && user.Password == password);
            if (user == null)
            {
                throw new ArgumentException("User or password is incorrect, try again");
            }
            LoggedUser.Current = FromEntity(user);
        }

        public void Logout()
        {
            LoggedUser.Current = null;
        }

        private static UserDTO FromEntity(User user)
        {
            return new UserDTO()
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role
            };
        }
    }
}
