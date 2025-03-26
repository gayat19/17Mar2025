using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLearningApp
{
    public class User  : IEquatable<User>
    {
        private string password = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { 
            get
            {

                var maskedPass = string.Empty;
                for (int i = 0; i < password.Length-2; i++)
                {
                    maskedPass += "*";
                }
                maskedPass += password.Substring(password.Length - 2);
                return maskedPass;
            }
            set
            {
                password = value;
            }
        }
        public bool ComparePassword(string password)
        {
            return this.password == password;
        }

        public bool Equals(User? other)
        {
           return other==null?false:this.Username == other.Username;
        }

        //public override bool Equals(object? obj)
        //{
        //    if (obj == null)
        //        return false;
        //    var user1 = this;
        //    var user2 = obj as User;//(User)obj;
        //    return user1.Username == user2.Username;
        //}

        public override string ToString()
        {
            return $"Username: {Username}, Password: {Password}";
        }
        
    }
}
