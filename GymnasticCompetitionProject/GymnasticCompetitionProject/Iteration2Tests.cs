using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnasticCompetitionProject
{
    class Iteration2Tests
    {
        // Iteration 2 tester

        // test 1
        public void TestOne()
        {
            Editor test = new Editor();
            try
            { test.Points = 11; }
            catch
            { Console.WriteLine("Test 1 lyckat!"); }

        }


        public void TestTwo()
        {
            Editor test = new Editor();

            string[] testArr = new string[] {"lag1", "lag2", "lag3"};
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Testa att lägga till poäng till medlemmar och sen resetta och manuellt räkna ut så att lag poängen är rätt. Kommer köras 5 ggr.(Inga medlems namn kommer att visas)");
            Console.ResetColor();
             int i = 0;
            while (i < 5)
            {
            test.ChangeMemberPoints(testArr);
            i += 1;
            }
            Console.WriteLine("Resultat ses manuellt.");
        }

        public void TestThree()
        {
            // Kan bara utföras manuellt. Väljer valet att ge ut/ resetta poäng medans inga lag är registrerade.
        }

        public void TestFour()
        {
            // Kan bara utföras manuellt. Väljer valet att ge ut/ resetta poäng medans man är utloggad.
        }
    }
}
