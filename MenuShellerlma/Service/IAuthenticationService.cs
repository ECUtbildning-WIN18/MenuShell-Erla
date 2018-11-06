using MenuShellerlma.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShellerlma.Service
{
    interface IAuthenticationService
    {
        User Authenticate(string username, string password);
    }
}
