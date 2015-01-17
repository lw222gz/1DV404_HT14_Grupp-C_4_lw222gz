using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnasticCompetitionProject
{
    public class LoggIn
    {
        private int _index;
        private string _userN;
        private string _userP;
        private string[] _accountNames = new string[] { "konto1", "konto2" };
        private string[] _accountPass = new string[] { "123", "321" };


        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
        public string[] AccountNames
        {
            get { return _accountNames; }
            set { _accountNames = value; }
        }

        public string[] AccountPasswords
        {
            get { return _accountPass; }
            set { _accountPass = value; }
        }

        public string UserName
        {
            get { return _userN; }
            set { _userN = value; }
        }

        public string UserPassword
        {
            get { return _userP; }
            set { _userP = value; }
        }

        public bool ValidateInfo()
        {
            Console.Write("Ange ditt användarnamn: ");
            UserName = Console.ReadLine();
            Console.Write("Ange ditt lösenord: ");
            UserPassword = getPassword();
            Console.WriteLine();

            Index = Array.IndexOf(AccountNames, UserName);
            if (Index == -1)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Kontonamnet finns inte registrerat.");
                Console.ResetColor();
            }
            else 
            {
                if (AccountPasswords[Index] == UserPassword)
                {

                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Inloggning lyckad!");
                    Console.ResetColor();
                    return true;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Lösenordet var fel.");
                    Console.ResetColor();
                }
            }
            return false;
        }

        public string getPassword()
        {
            string password = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            } while (key.Key != ConsoleKey.Enter);

            return password;
        }

    }
}
