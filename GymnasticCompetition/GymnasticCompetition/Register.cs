using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnasticCompetition
{
    public class Register
    {
        // fält
        public int j;
        public int c;
        public int i;
        private string[] savedTeamName;
        private string teamName;

        // egenskaper
        public string TeamName
        {
            get { return teamName; }
            set { teamName = value; }
        }

        public string[] SavedTeamNames 
        {
            get { return savedTeamName; }
            set { savedTeamName = value; }
        }

        //konstruktor
        public Register(string _teamName)
        {
            TeamName = _teamName;
        }

        // Kolla om lag namnet redan finns regisrerat
        public bool check(string[] names)
        {
            
            for (i = 0; i < names.Length; i += 1)
            {
                if (names[i] == TeamName)
                {
                    return false;
                }
            }
            return true;           
        }

        // Sparar lagnamnet i en array - denna är tänkt att användas av admins för att editera
        public string[] Save(string[] names)
        {
            SavedTeamNames = names;           
            return SavedTeamNames;
        }


    }
}
