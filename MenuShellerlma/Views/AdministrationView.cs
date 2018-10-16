using MenuShellerlma.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShellerlma.Views
{
    class AdministrationView : ConsoleView
    {
        private readonly IDictionary<string, User> _users;

        public AdministrationView(IDictionary<string, User> users)
        {
            _users = users;
        }
        public override string Display()
        {
            bool loop = true;

            do
            {
                base.Display();
                Console.WriteLine("\n # Admin menu");
                Console.WriteLine("\n (1) Manage users \n (2) Exit ");
                Console.Write(" >> ");

                var answer = Console.ReadKey(true);

                switch(answer.Key)
                {
                    case ConsoleKey.D1:
                        var manageUser = new ManageUserView(_users);
                        manageUser.Display();
                        break;
                    case ConsoleKey.D2:
                        loop = false;
                        break;
                    default:
                        break;
                }

            } while (loop);

            return "";
        }
    }
}
