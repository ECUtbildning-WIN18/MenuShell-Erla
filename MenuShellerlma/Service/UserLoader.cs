using System.Collections.Generic;
using MenuShellerlma.Domain;
using System.Data.SqlClient;
using System;

namespace MenuShellerlma.Service
{
    class UserLoader : IUserLoder
    {
        public IDictionary<string, User> LoadUsers()
        {
            var users = new Dictionary<string, User>();
            
            var connectionString = "Data Source=(local);Initial Catalog=MenuShell; Integrated Security=true";

            string queryString = "SELECT * FROM Users";

            using (var connection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();

                    var reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} {reader[1]} {reader[2]}");
                    }

                    reader.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }

            //var doc = XDocument.Load("Users.xml");

            //var root = doc.Root;

            //foreach (var element in root.Elements())
            //{
            //    var username = element.Attribute("username").Value;
            //    var password = element.Attribute("password").Value;
            //    var role = element.Attribute("role").Value;

            //    users.Add(username, new User(username, password, Role.Administrator));

            //}

            return users;
        }
    }
}
