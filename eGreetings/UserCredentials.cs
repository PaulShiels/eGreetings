using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGreetings
{
    class UserCredentials
    {
        public string Username { get; set; }
        public DateTime Dob { get; set; }
        public string Password { get; set; }

        public UserCredentials(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public UserCredentials(string Username, DateTime Dob, string Password)
        {
            this.Username = Username;
            this.Dob = Dob;
            this.Password = Password;
        }
    }
}
