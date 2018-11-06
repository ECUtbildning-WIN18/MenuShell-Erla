using MenuShellerlma.Domain;
using MenuShellerlma.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;

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

                string connectionString = "Data Source = (local); Initial Catalog = MenuShell; Integrated Security = true";

                Console.WriteLine("\n # Delete user \n");

                foreach (var user in _users)
                {
                    Console.WriteLine(user.Value.UserName);
                }

                Console.WriteLine("\n Witch one do you want to delete?");
                Console.Write(" >> ");

                var answer = Console.ReadLine();

                string queryString = ($"DELETE FROM [Users] WHERE [UserName] = '{answer}'");

                using (var connection = new SqlConnection(connectionString))
                {
                    var sqlCommand = new SqlCommand(queryString, connection);
                    try
                    {
                        connection.Open();
                        int rows = sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }

                Console.WriteLine("The user has been deleted!");
                Thread.Sleep(2000);
                //if(_users.ContainsKey(answer))

                //{
                //    Console.WriteLine($"Are you sure you want to delete {answer}? (Y)es (N)o");
                //    var deleteUser = Console.ReadLine();

                //    if(deleteUser == "y" || deleteUser == "Y")
                //    {
                //        _users.Remove(answer);
                //    }
                //    else
                //    {
                //        loop = false;
                //    }
                    
                //}
                //else
                //{
                //    loop = false;
                //}
            } while (loop);

            return "";
        }

    }
}
