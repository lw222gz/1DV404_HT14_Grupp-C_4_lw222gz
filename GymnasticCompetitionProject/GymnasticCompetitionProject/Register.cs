using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnasticCompetitionProject
{
    class RegisterCheck
    {
        private int _teamNumber = 0;
        private string _teamName;
        const int _maxnumberofTeams = 10;
        private string[] _teamNames = new string[_maxnumberofTeams];
          
        public string TeamName
        {
            get { return _teamName; }
            set { _teamName = value; }
        }

        public int TeamNumber
        {
            get { return _teamNumber; }
            set { _teamNumber = value; }
        }
        public string[] TeamNames
        {
            get{return _teamNames;}
            set {_teamNames = value; }
        }

        public int teamRegister()
        {
            Console.Write("Ange lagnamnet: ");
            TeamName = Console.ReadLine();
            if (TeamName.Trim() == "")
            { throw new ArgumentNullException(); }
            
            
            if (TeamNumber <= _maxnumberofTeams-1)
            {
                for (int t = 0; t < TeamNames.Length; t += 1)
                {
                    string compare = TeamNames[t];
                    if (compare != null)
                    {
                        if (compare.ToLower() == TeamName.ToLower())
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Detta lag är redan registrearat");
                            Console.ResetColor();
                            return TeamNumber;
                        }
                    }
                }
                TeamNames[TeamNumber] = TeamName;
                TeamNumber += 1;                
                return TeamNumber;                      // detta blev ett tillägg, nämn i reflektion.
            }
            else
            {               
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Mer lag kan ej registreras.");
                Console.ResetColor();               
            }
            return TeamNumber;         
        }

        public string[] getTeamNames()
        { return TeamNames; }

        public void setTeamNames(string[] updatedTeamNames)
        { TeamNames = updatedTeamNames; }
    }
}
