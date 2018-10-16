using MenuShellerlma.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShellerlma.Views
{
    class ManageUserView : ConsoleView
    {
        private readonly IDictionary<string, User> _users;

        public ManageUserView(IDictionary<string, User> users)
        {
            _users = users;
        }

        public override string Display()
        {

            bool loop = true;

            do
            {
                base.Display();

                Console.WriteLine("\n # Manage users");
                Console.WriteLine("\n (1) Add user\n (2) Delete user");
                Console.Write(" >> ");

                var answer = Console.ReadKey(true);

                switch (answer.Key)
                {
                    case ConsoleKey.D1:
                        var addUser = new AddUserView(_users);
                        addUser.Display();
                        break;

                    case ConsoleKey.D2:
                        var deleteUser = new DeleteUserView(_users);
                        deleteUser.Display();
                        break;
                    case ConsoleKey.Escape:
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
