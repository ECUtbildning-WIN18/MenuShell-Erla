using MenuShellerlma.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MenuShellerlma.Service
{
    class AuthenticationService : IAuthenticationService
    {
        private readonly IUserLoder _loadUser;

        public AuthenticationService(IUserLoder loadUser)
        {
            _loadUser = loadUser;
        }

        public User Authenticate(string username, string password)
        {
            string queryString = "SELECT * FROM [Users]";

            using (var connection = new SqlConnection(Helper.connectionString))
            {
                var sqlCommand = new SqlCommand(queryString, connection);

                connection.Open();

                var reader = sqlCommand.ExecuteReader();

                User user;

                while (reader.Read())
                {
                    if (reader["UserName"].ToString() == username && reader["Password"].ToString() == password)
                    {
                        var role = reader["Role"].ToString();

                        if(Enum.TryParse(role, out Role resault))
                        {
                            user = new User(username, password, resault);

                            return user;
                        }
                    }
                }
               

               
                return null;
            }

          
        }
    }
}
