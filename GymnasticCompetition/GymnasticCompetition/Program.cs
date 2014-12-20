using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnasticCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            string newName = "";
            int position = 0;
            int points = 0;
            int MaxNumberofAlllowedregisters = 10;
            int teamSize = 5;
            int index = 0;
            int i = 0;
            int c = 0;
            string teamName;
            string[,] AllMembers = new string[MaxNumberofAlllowedregisters,teamSize];
            int[,] AllMembersPoints = new int[MaxNumberofAlllowedregisters, teamSize];
            string[] teamNames = new string[MaxNumberofAlllowedregisters];
            string[] memberNames = new string[teamSize];

            Editor editor = null;
            Register register = null;


            do
            {
                Console.Clear();
                Menu();
                try
                {
                    //Uppgift 5.
                    //GymnasticCompetitionTest Tests = new GymnasticCompetitionTest();
                    //Tests.TestOne(); // Check - test lyckat, ett Argument Exception kastades !Feedback - 1 Fails, hade inte använt Trim() på straängen som sickades med.
                    //Tests.TestTwo(); // Check - test lyckat, ett Argument Exception kastades !Feedback - 0 Fails, tack vare att märkte problemet med test 1 så fixade jag det här också
                    //Tests.TestThree(); // Check - test lyckat, ett Argument Exception kastades !Feedback - 1 Fails, kollade aldrig i klassen editor om namnet redan fanns med i arrayn så jag skapade ett register objekt och använde Check metoden i den klassen.

                    //Uppgift 6. Interagations test (Ett test av följande funktioner efter att konfimerat att de övre testerna är lyckade)
                    //Tests.InteragtionTest(); //Användnings fall 1: Check - test lyckat, båda if-satserna går igenom vilket betyder att önskar resultat har hänt.
                    //Användnings fall 2: Check - test lyckat, den skriver ut "5" och "önskat resultat"x2. Dvs testet går igenom eftersom namnbyte/ poängbyte genomfördes lyckat och sattes på rätt array plats.

                    // switch sats meny

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 0: return;
                          
                            // registerar ett lag och lägger det i en array
                        case 1:
                            Console.Clear();
                            Console.Write("Ange lagets namn: ");
                            teamName = Console.ReadLine().ToLower();
                            Console.WriteLine();

                            register = new Register(char.ToUpper(teamName[0]) + teamName.Substring(1));
                            
                            
                            if (register.check(teamNames) == true)
                            {
                                teamNames[c] = char.ToUpper(teamName[0]) + teamName.Substring(1);                              
                                
                                for (i = 1; i < 6; i += 1)
                                {
                                    memberNames[i-1] = ReadMemberNames("Ange lagmedlem " + i + ": ");
                                    AllMembers[c, i-1] = memberNames[i-1];
                                }                              

                                
                                c += 1;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Detta lag är redan registrerat, vänligen försök igen");
                                Console.ResetColor();
                            }
                            break;
            
                            // editera möjligheter för namn ändring av lag eller deltagare
                        case 2:
                            if (register != null)
                            {
                                Console.Clear();
                                TeamShowMenu();

                                DispalyAll(AllMembers, teamNames);

                                index = DisplayTeam(AllMembers, teamNames, AllMembersPoints);
                                if (index == 0 || index > teamNames.Length)
                                {
                                    break;
                                }
                                Console.WriteLine();
                                Console.WriteLine("Ange ditt val. Andra tal avbryter.");
                                Console.WriteLine("1. Byta lag namn.");
                                Console.WriteLine("2. Byta deltagarenamn.");
                                
                                int secondChoice = int.Parse(Console.ReadLine());
                                Console.WriteLine();
                                
                                switch (secondChoice)
                                {
                                        
                                        
                                    case 1:
                                        Console.WriteLine("Skriv in det nya namnet:");
                                        newName = Console.ReadLine().ToLower();
                                        editor = new Editor(teamNames, index - 1, char.ToUpper(newName[0]) + newName.Substring(1));
                                        teamNames = editor.ChangeTeamName();
                                        
                                        changeSuccsess();
                                        break;

                                    case 2:
                                        Console.WriteLine("Vilken medlem vill du byta namnet på?");
                                        position = int.Parse(Console.ReadLine());

                                        if (position < 0 || position > 5)
                                        { throw new ArgumentOutOfRangeException(); }

                                        Console.WriteLine("Vilket är det nya namnet?");
                                        newName = Console.ReadLine();
                                        editor = new Editor(AllMembers, index-1, position-1, newName);
                                        AllMembers = editor.ChangeTeamMember();

                                        changeSuccsess();
                                        break;

                                    default: break;
                                    
                                
                            }
                                
                                
                            }
                            else 
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Inget lag har registrerats ännu.");
                                Console.ResetColor();
                            }
                            
                            break;

                            // edit möjligheter för att ändra eller ge ut poäng.
                        case 3:
                            if (register != null)
                            {
                                Console.Clear();
                                TeamShowMenu();

                                DispalyAll(AllMembers, teamNames);

                                index = DisplayTeam(AllMembers, teamNames, AllMembersPoints);
                                if (index == 0 || index > teamNames.Length)
                                {
                                    break;
                                }

                                Console.WriteLine();
                                Console.WriteLine("Vilken medlems poäng ska skrivas in?");

                                Console.Write("Medlem: ");
                                position = int.Parse(Console.ReadLine());

                                if (position < 0 || position > 5)
                                { throw new ArgumentOutOfRangeException(); }

                                Console.WriteLine("Vad ska deras poäng sättas till?");
                                points = int.Parse(Console.ReadLine());

                                editor = new Editor(AllMembersPoints, index - 1, position - 1, points);
                                AllMembersPoints = editor.AddPoints();

                                changeSuccsess();
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Inget lag har registrerats ännu.");
                                Console.ResetColor();
                            }
                            break;

                        default:
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Vänlig ange ett tal i intervallet 0-2");
                            Console.ResetColor();
                            break;
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ett fel Uppstod.");
                    Console.ResetColor();
                }


                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Tryck valfri tangent för att gå tillbaka till menyn - ESC avslutar.");
                Console.ResetColor();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            
        }

        // start meny
        static void Menu()
        {
            Console.WriteLine("Val:");
            Console.WriteLine("0. Avsluta.");
            Console.WriteLine("1. Registrera ett lag.");
            Console.WriteLine("2. Editera anmälda lag.");
            Console.WriteLine("3. Lägg till/ ändra deltagandes poäng.");
        }

        // registrerade lag meny
        static void TeamShowMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("===================================================");
            Console.WriteLine("=                                                 =");
            Console.WriteLine("=                Registrerade Lag                 =");
            Console.WriteLine("=                                                 =");
            Console.WriteLine("===================================================");
            Console.ResetColor();
        }

        // läser in en lagmedlems namn
        static string ReadMemberNames(string promt)
        {           
            while (true)
            {
                Console.Write(promt);
                string input = Console.ReadLine();
                if (input.Trim() == "")
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine();
                    Console.WriteLine("Var vänlig och ange ett namn.");
                    Console.ResetColor();
                }
                else
                {
                    return input;                   
                }
            }
        }

        // Visar upp alla lag och deras medlemmar
        static void DispalyAll(string[,] AllMembers, string[] teamNames)
        {
            int i;
            int j;
            for (i = 0; i < teamNames.Length; i += 1)
            {
                if (teamNames[i] == null)
                {
                    break;
                }
                Console.WriteLine("Lag {0}: {1}", i + 1, teamNames[i]);
                for (j = 1; j < 6; j += 1)
                {
                    Console.WriteLine("     Medlem {0}: {1}", j, AllMembers[i, j - 1]);
                }
            }
        }

        // visar upp ett lag och dess medlemmar och varje medlems poäng.
        static int DisplayTeam(string[,] AllMembers, string[] teamNames, int[,] AllMembersPoints)
        {
            int j;

            Console.WriteLine();
            Console.Write("Vilket lag vill du editera? ");
            int input = int.Parse(Console.ReadLine());           
            if (input >= 0 && input <= teamNames.Length)
            {
                Console.Clear();
                Console.WriteLine("Lag {0}: {1}", input, teamNames[input - 1]);
                for (j = 1; j < 6; j += 1)
                {
                    Console.WriteLine("     Medlem {0}: {1} - poäng : {2}", j, AllMembers[input - 1, j - 1], AllMembersPoints[input-1, j-1]);
                }
                return input;
            }
            return 0;
   
        }

        static void changeSuccsess()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Ändring Lyckad!");
            Console.ResetColor();
        }
    }
}
