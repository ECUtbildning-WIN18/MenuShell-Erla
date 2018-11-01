using MenuShellerlma.Domain;
using MenuShellerlma.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;

namespace MenuShellerlma.Views
{
    class SearchUserView : ConsoleView
    {
        private readonly IDictionary<string, User> _users;

        public SearchUserView(IDictionary<string, User> users)
        {
            _users = users;
        }

        public override string Display()
        {
            //var count = 0;
            bool loop = true;

            do
            {
                base.Display();
                
                Console.WriteLine("\n Search by username: ");
                Console.Write(" >> ");

                var answer = Console.ReadLine();

                var choice = new SearchSql();

                choice.Search(answer);

                //foreach (var user in _users)
                //{
                //    if (user.Value.UserName.Contains(answer))
                //    {
                //        Console.WriteLine(user.Key);
                //        count += 1;
                //        //var search = user.Where(x => x.UserName == username);
                //    }
                //}

                //if(count < 1)
                //{
                //    Console.WriteLine($"No user found matching the search term {answer}");
                //    Thread.Sleep(2000);
                //    Console.Clear();
                //    Display();
                    
                //}


                //foreach (var user in _users)
                //{
                //    if(user.Value.UserName == answer)
                //    { 
                //       Console.WriteLine(user.Key);
                //    }
                //   //else if (answer != user.Value.UserName)
                //   // {
                //   //     Console.WriteLine($"No user found matching the search term {answer}");
                //   //     Thread.Sleep(2000);
                //   //     Console.Clear();
                //   //     //loop = false;
                //   //     Console.WriteLine("\n Press esc to try again!");
                //   //     var key = Console.ReadKey();

                //   //     if (key.Key == ConsoleKey.Escape)
                //   //     {
                //   //         var searchUser = new SearchUserView(_users);
                //   //         searchUser.Display();
                //   //     }
                //   // }  
                //}

                Console.WriteLine("\n (D)elete user? (B)ack");
                Console.Write(" >> ");

                var answerDelete = Console.ReadKey(true);

                if (answerDelete.Key == ConsoleKey.D)
                {
                    var delete = new DeleteUserView(_users);
                    delete.Display();
                }
                else if(answerDelete.Key == ConsoleKey.B)
                {
                    var back = new ManageUserView(_users);
                    back.Display();
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

