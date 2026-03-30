using _08_StatiClassExtensionMethodsExceptions.Exceptions;
using _08_StatiClassExtensionMethodsExceptions.Models;

namespace _08_StatiClassExtensionMethodsExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var loginSystem = new LoginSystem();

            while(true)
            {
                Console.WriteLine("Username daxil edin:");
                string username = Console.ReadLine();

                Console.WriteLine("Password daxil edin:");
                string password = Console.ReadLine();

                try
                {
                    bool succes = loginSystem.Login(username, password);
                    if (succes)
                        break;
                }
                catch(InvalidUsernameException ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
                catch(InvalidPasswordException ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
                catch (UserNotFoundException ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                    loginSystem.ShowUsers();
                }
                catch (IncorrectPasswordException ex)
                {
                    Console.WriteLine("WARNING: " + ex.Message);
                }
                catch (AccountLockedException ex)
                {
                    Console.WriteLine("CRITICAL: " + ex.Message);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("UNEXPECTED ERROR: " + ex.Message);
                }
            }
        }
    }
}
