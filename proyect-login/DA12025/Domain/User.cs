using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        private string name;
        private string lastname;
        private string email;
        private string password;
        private string role;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                name = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("LastName cannot be null or empty");
                }
                lastname = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Email cannot be null or empty");
                }
                email = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Password cannot be null or empty");
                }
                password = value;
            }
        }

        public string Role
        {
            get
            {
                return role;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Role cannot be null or empty");
                }
                role = value;
            }
        }

        public User(string name, string lastname, string email, string password, string role)
        {
            Name = name;
            LastName = lastname;
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
