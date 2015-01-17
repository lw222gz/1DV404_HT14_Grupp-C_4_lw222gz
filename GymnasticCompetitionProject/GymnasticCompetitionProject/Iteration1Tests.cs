using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnasticCompetitionProject
{
    public class Iteration1Tests
    {
        public void testOne()
        {
            LoggIn logginTEST = new LoggIn();
            Console.WriteLine("Vänligen ange: FelaktigktAnvändarnamn");
            Console.WriteLine("Vänligen ange: FelaktigtLösenord");
            bool test = true;

            test = logginTEST.ValidateInfo();

            if (test == true)
            { Console.WriteLine("Test misslyckat."); }
            if (test == false)
            { Console.WriteLine("Test lyckat!"); }
        }

        public void testTwo()
        {
            LoggIn LogginTEST = new LoggIn();
            Console.WriteLine("vänligen ange som användar namn: konto1"); //rätt användar namn
            Console.WriteLine("vänligen ange som lösen ord: 321"); // ett lösen till ett annat konto

            bool test = true;
            test = LogginTEST.ValidateInfo();

            if (test == true)
            {
                Console.WriteLine("Test misslyckat.");
            }
            if (test == false)
            {
                Console.WriteLine("Test lyckat!");
            }
        }

        public void testThree()
        {
            RegisterCheck registerTEST = new RegisterCheck();
            Console.WriteLine("Registrera 2 likadana namn!");
            registerTEST.teamRegister();
            registerTEST.teamRegister();

            if (registerTEST.TeamNames[1] != null)
            {
                Console.WriteLine("Test misslyckat");
            }
            else
            {
                Console.WriteLine("Test lyckat!");
            }
        }

        public void testFour()
        {
            RegisterCheck registerTEST = new RegisterCheck();
            registerTEST.TeamNames = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            registerTEST.teamRegister();
            Console.WriteLine("Om registrering genomfördes lyckat så misslyckades testet.");           
        }              
    }
}
