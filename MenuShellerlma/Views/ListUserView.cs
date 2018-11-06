using MenuShellerlma.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShellerlma.Views
{
    class ListUserView : ConsoleView
    {
        private readonly IDictionary<string, User> _users;

        public ListUserView(IDictionary<string, User> users)
        {
            _users = users;
        }

        public override string Display()
        {
            bool loop = true;

            do
            {
                base.Display();

                Console.WriteLine("\n # List of users ");

                foreach(var user in _users)
                {
                    Console.WriteLine(user.Value.UserName);
                }

                Console.WriteLine("\n Press esc to get back!");
                var key = Console.ReadKey();

                if(key.Key == ConsoleKey.Escape)
                {
                    var adview = new AdministrationView(_users);
                    adview.Display();
                }

            } while (loop);
            return "";
        }
    }
}
