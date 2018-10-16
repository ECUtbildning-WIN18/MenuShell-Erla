using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using MenuShellerlma.Domain;

namespace MenuShellerlma.Service
{
    class UserLoader : IUserLoder
    {
        public IDictionary<string, User> LoadUsers()
        {
            var users = new Dictionary<string, User>();

            var doc = XDocument.Load("Users.xml");

            var root = doc.Root;

            foreach (var element in root.Elements())
            {
                var username = element.Attribute("username").Value;
                var password = element.Attribute("password").Value;
                var role = element.Attribute("role").Value;

                users.Add(username, new User(username, password, Role.Administrator));

            }

            return users;
        }
    }
}
