using MenuShellerlma.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MenuShellerlma.Service
{
    class AddSql
    {
        public void Add(User user)
        {
            using (var connection = new SqlConnection(Helper.connectionString))
            {
                connection.Open();

                var sqlQuery = String.Format("INSERT INTO [Users](UserName, Password, Role) VALUES('{0}','{1}','{2}');" +
                    "SELECT @@Identity", user.UserName, user.Password, user.Role);

                var command = new SqlCommand(sqlQuery, connection);

               command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();
                connection.Dispose();

            }
        }
    }
}
