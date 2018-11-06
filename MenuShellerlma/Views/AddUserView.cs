using MenuShellerlma.Domain;
using MenuShellerlma.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShellerlma.Views
{
    class AddUserView : ConsoleView
    {
        private readonly IDictionary<string, User> _users;

        public AddUserView(IDictionary<string, User> users)
        {
            _users = users;
        }

        public override string Display()
        {
            bool loop = true;

            do
            {
                base.Display();

                Console.WriteLine("\n # Add users");

                Console.Write("\n Username: ");
                string username = Console.ReadLine();

                Console.Write(" Password: ");
                string password = Console.ReadLine();

                Console.Write(" Role: ");
                string role = Console.ReadLine();

                Console.WriteLine("Is this correct? (Y)es (N)o");

                var answer = Console.ReadKey(true);

                var user = new User(username, password, (Role)Enum.Parse(typeof(Role), role));


                if (answer.Key == ConsoleKey.Y)
                {
                    var sqlAdd = new AddSql();

                    sqlAdd.Add(user);

                    loop = false;
                    //if (!_users.ContainsKey(user.UserName))
                    //{
                    //    _users.Add(user.UserName, user);
                    //}

                    //ListUserView list = new ListUserView(_users);
                    //list.Display();

                }
                else if (answer.Key == ConsoleKey.N)
                {
                    Display();
                    
                }

            } while (loop);

            return "";
        }
    }
}
