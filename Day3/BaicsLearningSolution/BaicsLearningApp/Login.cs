using BasicLearningApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BaiscLearningApp
{
    internal class Login
    {
        private User TakeUserDetails()
        {
            User user = new User();
            Console.WriteLine("Enter the username");
            user.Username = Console.ReadLine() ?? "";//null colasing operator
            Console.WriteLine("Enter the password");
            user.Password = Console.ReadLine() ?? "";
            return user;
        }
        private bool CompareUser(User user)
        {
            User validUser = new User()
            {
                Username = "ABC",
                Password = "123"
            };
            if (validUser.Equals(user) && user.ComparePassword("123"))
                return true;
            return false;
        }
        public void DoLogin()
        {
            int count = 0;
            do
            {
                User user = TakeUserDetails();
                if (CompareUser(user))
                {
                    Console.WriteLine("Login success");
                    break;
                }
                else
                {
                    Console.WriteLine("Login failed");
                    count++;
                }
            } while (count < 3);

        }
    }
}
