using _08_StatiClassExtensionMethodsExceptions.Models;
using _08_StatiClassExtensionMethodsExceptions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_StatiClassExtensionMethodsExceptions.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsLocked { get; set; } = false;
        public int FailedAttempts { get; set; } = 0;

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
