using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        List<UserDTO> GetUsers();
        UserDTO GetUser(string email);
        void AddUser(UserDTO user);
    }
}
