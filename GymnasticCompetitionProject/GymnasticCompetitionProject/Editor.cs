using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnasticCompetitionProject
{
    class Editor
    {
        // fält
        public bool pointsAquired = false;
        const int MaxNumberofAllowedRegisters = 10;
        const int teamSize = 5;
        private int _points;
        private int _index; 
        private int _position; 
        private string _newName;
        private int[] _teamPoints = new int[MaxNumberofAllowedRegisters];
        private int[] _cloneTeamPoints = new int[MaxNumberofAllowedRegisters];
        private string[] _teamNames = new string[MaxNumberofAllowedRegisters]; 
        private int[,] _allMembersPoints = new int[MaxNumberofAllowedRegisters, teamSize];
        private string[,] _allMembers = new string[MaxNumberofAllowedRegisters, teamSize];

        // egenskaper
        public int Points
        {
            get { return _points; }
            set
            {
                if (value < 0 || value > 10)        
                { throw new ArgumentOutOfRangeException(); }

                _points = value;
            }
        }

        public int[] CloneTeamPoints
        {
            get { return _cloneTeamPoints; }
            set { _cloneTeamPoints = value; }
        }

        public int[] TeamPoints
        {
            get { return _teamPoints; }
            set { _teamPoints = value; }
        }

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        public int Position
        {
            get { return _position; }
            set
            {
                if (value < 0 || value > 5) 
                { throw new ArgumentOutOfRangeException(); }

                _position = value;
            }
        }

        public string NewName
        {
            get { return _newName; }
            set
            {
                if (value.Trim() == "")
                { throw new ArgumentException(); }
                _newName = value;
            }
        }    

        public string[] TeamNames
        {
            get { return _teamNames; }
            set { _teamNames = value; }
        }

        public string[,] AllMembers
        {
            get { return _allMembers; }
            set { _allMembers = value; }
        }

        public int[,] AllMemberPoints
        {
            get { return _allMembersPoints; }
            set { _allMembersPoints = value; }
        }

        // läser in lag namn.
        public void ReadMemberNames(int TeamNumber)
        {            

            for (int i = 0; i < teamSize; i += 1)
            {
                Console.Write("Ange lagmedlem {0}: ", i+1);
                string name = Console.ReadLine();
                if (name.Trim() == "")
                {
                    Console.WriteLine("Det du skrev in kan inte ses som ett namn.");
                    i -= 1;
                }
                else
                {
                    AllMembers[TeamNumber, i] = name;
                }
            }           
        }

        // meny för namn editering
        public string[] ChangeNames(string[] teamNames)
        {
            ShowAllTeams(teamNames);
            
            Console.Write("Vilket lag vill du editera? ");
            Index = int.Parse(Console.ReadLine());
            Index -= 1; // för att få rätt array plats.

            ShowChosenTeam(teamNames);
            Console.WriteLine();
            Console.Write("Vad vill du göra?");
            Console.WriteLine("0. Avbryta.");
            Console.WriteLine("1. Byta lag namn.");
            Console.WriteLine("2. Byta medlems namn.");
            int choice = int.Parse(Console.ReadLine());
            
            Console.WriteLine();

            switch (choice)
            {
                case 0: break;

                case 1: TeamNames = ChangeTeamName(teamNames);
                    break;

                case 2: ChangeMemberName();
                    break;

                default: Console.WriteLine("Du angav inte några av de angivna valen. Vänligen försök igen.");
                    break;
            }
            return TeamNames;           
        }

        // byter utvalt lag namn
        public string[] ChangeTeamName(string[] teamnames) // fick lägga till
        {
            Console.Write("Vad är det nya namnet? ");
            NewName = Console.ReadLine();
            teamnames[Index] = NewName;

            return teamnames;
        }

        // byter utvald medlems namn 
        public void ChangeMemberName() // fick lägga till
        {
            Console.Write("Vilken medlem vill du byta namnet på? ");
            Position = int.Parse(Console.ReadLine());
            Position -= 1;

            Console.Write("Vad är det nya namnet? ");
            NewName = Console.ReadLine();

            AllMembers[Index, Position] = NewName;
            
        }


        // en meny för att edita poäng
        public void ChangeMemberPoints(string[] teamnames)
        {
            ShowAllTeams(teamnames);

            Console.Write("Viket lag ska få poäng?");
            Index = int.Parse(Console.ReadLine());
            Index -= 1;

            ShowChosenTeam(teamnames);          

            Console.WriteLine();
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("0. Avsluta.");
            Console.WriteLine("1. Lägga till poäng.");
            Console.WriteLine("2. Resetta en medlems poäng.");
            Console.Write("Val: ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 0: break;

                case 1: AddMemberPoints();
                    break;

                case 2: ResetMemberPoints();

                    break;

                default: Console.WriteLine("Du har inte givet ett tal inom intervallet och sickas tillbaka till menyn.");
                    break;
            }
            
        }


        // lägger till en medlems oäng
        public void AddMemberPoints() // hade inte me di planeringen - iteration 2
        {
            Console.Write("Vilken medlems ska få poäng? ");
            Position = int.Parse(Console.ReadLine());
            Position -= 1;

            if (AllMemberPoints[Index, Position] != 0)
            {
                Console.WriteLine("Hur mycket poäng ska adderas?(0-10) ");
                Points = int.Parse(Console.ReadLine());

                ConfirmChoice("addPoints");
            }
            else
            {
                Console.WriteLine("Hur mycket poäng ska deltagaren få?(0-10) ");
                Points = int.Parse(Console.ReadLine());

                ConfirmChoice("addPoints");
            }
        }


        // resettar en medlems poäng
        public void ResetMemberPoints()  // hade inte med i planeringen- iteration 2
        {
            Console.Write("Vilken medlems poäng ska resetas?");
            Position = int.Parse(Console.ReadLine());
            Position -= 1;
            
            ConfirmChoice("resetPoints");
        }

        // frågar om användaren är nöjd med sina val.
        public void ConfirmChoice(string type)
        {
            Console.WriteLine("Är du säker?");
            Console.WriteLine("1. Ja");
            Console.WriteLine("2. Nej");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    if (type == "resetPoints")
                    {
                        AllMemberPoints[Index, Position] = 0;
                        
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Ändring utförd.");
                        Console.ResetColor();
                    }
                    if (type == "addPoints")
                    {
                        AllMemberPoints[Index, Position] += Points;
                        
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Ändring utförd.");
                        Console.ResetColor();
                        
                    }

                    UpdateTeamPoints();
                    pointsAquired = true;
                    break;

                case 2: Console.WriteLine("Ingen ändring har skett");
                    break;

                default: Console.WriteLine("Du har inte givet ett tal inom intervallet och sickas tillbaka till menyn.");
                    break;
            }
        }

        // uppdaterar lagets total poäng.
        public void UpdateTeamPoints()
        {
            TeamPoints[Index] = 0; 
            for (int i = 0; i < teamSize; i += 1)
            {
                TeamPoints[Index] += AllMemberPoints[Index, i];
            }
        }

        // visar 1 lag som användaren har valt
        public void ShowChosenTeam(string[] teamNames) // glömde lägga in i planering
        {
            Console.Clear();
            Console.WriteLine("Lag {0}: {1}     Lag poäng: {2}",Index+1, teamNames[Index], TeamPoints[Index]);
            for (int i = 0; i < teamSize; i += 1)
            {
                Console.WriteLine("     Medlem {0}: {1}      Poäng: {2}", i+1, AllMembers[Index, i], AllMemberPoints[Index, i]);
            }
        }

        // en meny av alla lag
        public void ShowAllTeams(string[] teamNames) // glömde lägga in i planering
        {
            Console.Clear();
            int j = 0;
            foreach (string name in teamNames)
            {
                if (teamNames[j] == null)
                { break; }

                j += 1;
                Console.WriteLine("Lag {0}: {1}     Lag poäng:{2}", j, teamNames[j-1], TeamPoints[j-1]);
                for (int i = 0; i < teamSize; i += 1)
                {
                    Console.WriteLine("     Medlem {0}: {1}", i+1, AllMembers[j-1,i]);
                }
            }
 
        }

        public void DisplayTeamOrder(string[] teamNames)
        {
            if (pointsAquired == true)
            {
                TeamNames = teamNames;
                CloneTeamPoints = TeamPoints;
                Array.Sort(CloneTeamPoints);
                Array.Reverse(CloneTeamPoints); // så högsta kommer överst

                for (int i = 0; i < MaxNumberofAllowedRegisters; i += 1)
                {
                    int value = CloneTeamPoints[i];
                    int ArrPosition = Array.IndexOf(TeamPoints, value);
                    //Console.WriteLine(ArrPosition);

                    if (TeamNames[ArrPosition] == null)
                    { break; }

                    Console.WriteLine("Lag Nr. {0} : {1,3} Poäng: {2}", i + 1, TeamNames[ArrPosition], TeamPoints[ArrPosition]);
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Inga lag har än fått poäng.");
                Console.ResetColor();
            }
        }
    }
}
