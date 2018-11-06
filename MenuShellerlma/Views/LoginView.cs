using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MenuShellerlma.Domain;
using MenuShellerlma.Service;

namespace MenuShellerlma.Views
{
    class LoginView
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginView(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public User Display()
        {
            User validUser = null;

            do
            {
                Console.Clear();

                Console.WriteLine("\n Please log in!");

                Console.Write("\n Username: ");
                string username = Console.ReadLine();

                Console.Write(" Password: ");
                string password = Console.ReadLine();

                Console.WriteLine("\n Is this correct? (Y)es (N)o");
                Console.Write(" >> ");

                var answer = Console.ReadKey(true);

                if (answer.Key == ConsoleKey.Y)
                {
                    validUser = _authenticationService.Authenticate(username, password);

                    if (validUser == null)
                    {
                        Console.Clear();
                        Console.WriteLine("\n Login faild, please try again!");
                        Thread.Sleep(2000);
                    }
             
                }
                else if (answer.Key == ConsoleKey.N)
                {

                }
            } while (validUser == null);
            return validUser;
        }
    }
}
