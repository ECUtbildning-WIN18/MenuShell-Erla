using MenuShellerlma.Service;
using MenuShellerlma.Views;
using System;

namespace MenuShellerlma
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "======== LoveHeard pet clinic ========";
            Console.ForegroundColor = ConsoleColor.Magenta;
            //Console.BackgroundColor = ConsoleColor.Magenta;

            var userLoader = new UserLoader();

            var authenticationService = new AuthenticationService(userLoader);

            var loginView = new LoginView(authenticationService);

            var user = loginView.Display();

            var users = userLoader.LoadUsers();

            if (user.Role == Domain.Role.Administrator)
            {
                
                var adminView = new AdministrationView(users);

                adminView.Display();
            }
        }
    }
}
