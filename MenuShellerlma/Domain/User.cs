using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShellerlma.Domain
{
    class User
    {
        public string UserName { get; }
        public string Password { get; }
        public Role Role { get; }

        public User(string userName, string password, Role role)
        {
            UserName = userName;
            Password = password;
            Role = role;
        }
    }
}
