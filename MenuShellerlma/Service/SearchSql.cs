using MenuShellerlma.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;

namespace MenuShellerlma.Service
{
    class SearchSql
    {
        public void Search(string choice)
        {
            string quersyString = "SELECT * FROM [Users]";

            var count = 0;

            using (var connection = new SqlConnection(Helper.connectionString))
            {
                var sqlCommand = new SqlCommand(quersyString, connection);

                connection.Open();

                var reader = sqlCommand.ExecuteReader();

                User user;

                //Console.WriteLine("Result: ");

                while (reader.Read())
                {
                    if (reader["UserName"].ToString().Contains(choice))
                    {
                        Console.WriteLine($"{reader[0]}");
                        count += 1;
                    }
                }

                reader.Close();
            }

            if (count < 1)
            {
                Console.WriteLine($"No user found matching the search term{choice}");
                Thread.Sleep(2000);
            }
            //else if (count >= 1)
            //{
            //    Console.WriteLine("\n (D)elete");

            //    var answer = Console.ReadKey(true);

            //    if (answer.Key == ConsoleKey.D)
            //    {
            //        bool reault = false;

            //        string sqlQuery = string.Format("DELETE FROM Users WHERE UserName = {0}");
            //        SqlConnection connection = new SqlConnection(Helper.connectionString);
            //        connection.Open();

            //        SqlConnection command = new SqlCommand(sqlQuery, connection);

            //        int rowDeleteCount = command.();
            //        if (rowDeleteCount != 0)
            //            reault = true;



            //        Console.Clear();
            //        Console.Write("Delete >>");
            //        var setChoice = Console.ReadLine();
            //        if ()
            //        {
            //            Console.WriteLine($"Delete user {setChoice}? (Y)es (N)o");
            //            var answer2 = Console.ReadKey(true);

            //            if (answer2.Key == ConsoleKey.Y)
            //            {

            //            }
            //            else if(answer2.Key == ConsoleKey.N)
            //            {
                           
            //            }
            //        }
            //    }
            //}
        }
    }
}
