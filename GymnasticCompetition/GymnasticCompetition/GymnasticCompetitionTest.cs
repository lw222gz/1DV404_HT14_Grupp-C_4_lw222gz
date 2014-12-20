using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnasticCompetition
{
    class GymnasticCompetitionTest
    {
        //test 1: Register tar emot parametrar "" och " "
        public void TestOne()
        {
            Register testOne = new Register("");

            Register testOne1 = new Register(" ");

            // förväntat reslultat - Kastar ett undantag.
        }

        //test 2: Editor tar emot parametrar "" och " " (bara de värderna som är möjliga att sicka med till klassen, dvs. namn)
        public void TestTwo()
        {

            string[,] a = new string[10,5];
            int _index = 1;
            int _position = 1;
            string newname = " ";

            Editor testTwo = new Editor(a, _index, _position, newname);
        }


        //test 3: Editor byter namn på lag 1 till ett namn som lag 2 har
        public void TestThree()
        {

            string[] teamnames = new string[10];
            int index = 1;
            string newName = " ";
            
            Editor testThree = new Editor(teamnames, index, newName);
        }

        // uppgift 6.
        public void InteragtionTest()
        {
            // användingsfall 1:
            string notAvalibel = "a";
            string[] names = new string[10];
            names[0] = notAvalibel;

            Register tester = new Register("b");
            
            if (tester.check(names) == true)
            {
                Console.WriteLine("Testfall 1 lyckat!");
            }

            tester = new Register("a");
            if (tester.check(names) == false)
            {
                Console.WriteLine("Testfall 2 lyckat!");
            }


            // användingsfall 2:
            int[,] allMP = new int[10, 5];
            int index = 1;
            int position = 1;
            int points = 5;
            string[,] allM = new string[10, 5];
            string newName = "Önskat resultat";

            // poäng byte
            Editor editor = new Editor(allMP, index, position, points);
            editor.AddPoints();
            Console.WriteLine(allMP[1,1]);
            // personnamn byte
            editor = new Editor(allM, index, position, newName);
            editor.ChangeTeamMember();
            Console.WriteLine(allM[1,1]);
            // lagnamn 
            editor = new Editor(names, index, newName);
            editor.ChangeTeamName();
            Console.WriteLine(names[1]);

        }
        
    }
}
