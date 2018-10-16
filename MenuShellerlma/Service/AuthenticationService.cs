using MenuShellerlma.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShellerlma.Service
{
    class AuthenticationService : IAuthenticationService
    {
        private readonly IUserLoder _loadUser;

        public AuthenticationService(IUserLoder loadUser)
        {
            _loadUser = loadUser;
        }

        public User Authenticate(string username, string password)
        {
            User user = null;

            var users = _loadUser.LoadUsers();

            if(users.ContainsKey(username) && users[username].Password == password)
            {
                user = users[username];
            }
            return user;
        }
    }
}
