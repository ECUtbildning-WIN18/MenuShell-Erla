using MenuShellerlma.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShellerlma.Views
{
    class DeleteUserView : ConsoleView
    {
        private readonly IDictionary<string, User> _users;

        public DeleteUserView(IDictionary<string, User> users)
        {
            _users = users;
        }

        public override string Display()
        {
            bool loop = true;

            do
            {
                base.Display();

                Console.WriteLine("\n # Delete user");

                foreach(var user in _users)
                {
                    Console.WriteLine(user.Value.UserName);
                }

                Console.WriteLine("\n Witch one do you want to delete? ");
                Console.Write(" >> ");

                var answer = Console.ReadLine();
                if(_users.ContainsKey(answer))
                {
                    _users.Remove(answer);
                }
                else
                {
                    loop = false;
                }
            } while (loop);

            return "";
        }

    }
}
