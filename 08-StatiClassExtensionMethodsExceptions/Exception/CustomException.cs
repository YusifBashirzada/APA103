using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_StatiClassExtensionMethodsExceptions.Exceptions
{
    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException() : base("Username bos ola bilmez ve 3 simvoldan az ola bilmez") { }
        public InvalidUsernameException(string message) : base(message) { }
    }

    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException() : base("Password bos ola bilmez ve 6 simvoldan az ola bilmez") { }
        public InvalidPasswordException(string message) : base(message) { }
    }

    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("Istifadeci tapilmadi") { }
        public UserNotFoundException(string message) : base($"Istifadeci  tapilmadi") { }
    }

    public class IncorrectPasswordException : Exception
    {
        public int AttemptsLeft { get; set; }
        public IncorrectPasswordException(int attemptsleft) : base($"Password duz deyil! Qalan cehd sayi: {attemptsleft}")
        {
            AttemptsLeft = attemptsleft;
        }
    }

    public class AccountLockedException : Exception {
        public AccountLockedException() : base("3 defeden artiq sifre daxil etdiyiniz ucun ve ya daha onceden hesabiniz bloklanib") { }
    }
}
