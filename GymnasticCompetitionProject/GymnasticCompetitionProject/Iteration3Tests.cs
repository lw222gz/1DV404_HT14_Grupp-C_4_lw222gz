using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnasticCompetitionProject
{
    class Iteration3Tests
    {
        public void TestOne()
        {
            // kan bara testas manuellt.
        }

        public void TestTwo()
        {
            string[] testArray = new string[] { "Lag1", "Lag2", "Lag3" };
            Editor testare = new Editor();
            testare.DisplayTeamOrder(testArray);
            Console.WriteLine("Ett meddelande om att lagen inte ha fått poäng än ska visas upp. Annars är detta test ett misslyckat.");
        }

        public void TestThree()
        {
            // kan bara testas manuellt.
        }
    }
}
