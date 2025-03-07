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
    public class UserService : IUserService
    {
        private readonly InMemoryDatabase _inMemoryDatabase;

        public UserService(InMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }
        public void AddUser(UserDTO user)
        {
            ValidateUserEmail(user.Email);
            _inMemoryDatabase.Users.Add(ToEntity(user));
        }

        public List<UserDTO> GetUsers()
        {
            List<UserDTO> usersDTO = new List<UserDTO>();

            foreach (var user in _inMemoryDatabase.Users)
            {
                usersDTO.Add(FromEntity(user));
            }
            return usersDTO;
        }

        public void DeleteUser(string email)
        {
            UserDTO userToDelete = GetUser(email);
            User? user = _inMemoryDatabase.Users.Find(u => u.Email == userToDelete.Email);
            _inMemoryDatabase.Users.Remove(user);
        }

        public UserDTO GetUser(string email)
        {
            User? user = _inMemoryDatabase.Users.FirstOrDefault(user => user.Email == email);
            if (user == null)
            {
                throw new ArgumentException("Cannot find user with this email");
            }
            return FromEntity(user);
        }

        private void ValidateUserEmail(string email)
        {
            foreach (var user in _inMemoryDatabase.Users)
            {
                if (user.Email == email)
                {
                    throw new ArgumentException("There`s a user already defined with that email");
                }
            }
        }

        private User ToEntity(UserDTO userDTO)
        {
            return new User(userDTO.Name, userDTO.LastName, userDTO.Email, userDTO.Password, userDTO.Role) { };
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
