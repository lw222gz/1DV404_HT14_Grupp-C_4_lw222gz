using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnasticCompetition
{
    public class Editor
    {
        // fält
        private int points;
        private int index;
        private int position;
        private string newName;
        private int[,] allMembersPoints;
        private string[,] allMembers;
        private string[] teamNames;

        // egenskaper
        public int Points
        {
            get { return points; }
            set {
                if (value < 0 || value > 10)        // poängen ranka inom ett 0-10 system?
                {   throw new ArgumentOutOfRangeException();    } 

                    points = value; 
                }
        }
        public int Position
        {
            get { return position; }
            set {
                    if (value < 0 || value > 4) // är bara 5 medlemmar i varje lag. alltså array positioner 0-4.
                    {   throw new ArgumentOutOfRangeException();   }

                    position = value; 
                }
        }

        public string NewName
        {
            get { return newName; }
            set {
                if (value == "")
                { throw new ArgumentException(); }
                    newName = value; 
                }
        }
        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        public int[,] AllMemberPoints
        {
            get { return allMembersPoints; }
            set { allMembersPoints = value; }
        }

        public string[,] AllMembers
        {
            get { return allMembers; }
            set { allMembers = value; }
        }

        public string[] TeamNames
        {
            get { return teamNames; }
            set { teamNames = value; }
        }

        //Konstruktor för ändring av/ lägga till poäng.
        public Editor(int[,] _allMembersPoints, int _index, int _position, int _points)
        {
            AllMemberPoints = _allMembersPoints;
            Points = _points;
            Index = _index;
            Position = _position;
        }


        // konstruktor för personnamn byte
        public Editor(string[,] _allMembers, int _index, int _position, string _newName)
        {
            AllMembers = _allMembers;
            NewName = _newName;
            Index = _index;
            Position = _position;
        }

        // kontstuktor för lagnamn byte
        public Editor(string[] _teamNames, int _index, string _newName)
        {
            NewName = _newName;
            Index = _index;
            TeamNames = _teamNames;
        }

        // retunerar en ny array med poäng i sig.
        public int[,] AddPoints()
        {
            AllMemberPoints[Index, Position] = Points;
            return AllMemberPoints;
        }

        // byter namn på ett lag och retunerar det nya i en ny array
        public string[] ChangeTeamName()
        {
            TeamNames[Index] = NewName;
            return TeamNames;
        }

        public string[,] ChangeTeamMember()
        {
            AllMembers[Index, Position] = NewName;
            return AllMembers;
        }
    }
}
