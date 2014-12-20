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
        private string teamName;

        // egenskaper
        public string TeamName
        {
            get { return teamName; }
            set {
                if (value == "")
                {
                    throw new ArgumentException();
                }
                    teamName = value; 
                }
        }


        //konstruktor
        public Register(string _teamName)
        {
            TeamName = _teamName.Trim();
        }

        // Kolla om lag namnet redan finns regisrerat
        public bool check(string[] names)
        {
            
            for (int i = 0; i < names.Length; i += 1)
            {
                if (names[i] == TeamName)
                {
                    return false;
                }
            }
            return true;           
        }       
    }
}
