using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnasticCompetition
{
    public class ShowResult
    {
        // fält
        private string[] teamNames;
        private string[,] allMembers;

        // egenskaper
        public string[] TeamNames
        {
            get { return teamNames; }
            set { teamNames = value; }
        }

        public string[,] AllMembers 
        {
            get { return allMembers; }
            set { allMembers = value; }
        }
        // konstruktor
        public ShowResult(string[] _teamName, string[,] _allMembers)
        {
            TeamNames = _teamName;
            AllMembers = _allMembers;
        }

        // retunerar en array med namnen
        public string[] getTeamNames()
        {
            return TeamNames;
        }

        // retunerar en array med lagmedlemmarnas namn
        public string[,] getMemberNames()
        {
            return AllMembers;
        }
    }
}
