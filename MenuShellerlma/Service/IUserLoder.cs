using MenuShellerlma.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShellerlma.Service
{
    interface IUserLoder
    {
        IDictionary<string, User> LoadUsers();
    }
}
