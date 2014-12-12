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
            int MaxNumberofAlllowedregisters = 10;
            int teamSize = 5;
            int j = 0;
            int i = 0;
            int c = 0;
            string teamName;
            string[,] AllMembers = new string[MaxNumberofAlllowedregisters,teamSize];
            string[] teamNames = new string[MaxNumberofAlllowedregisters];
            string[] memberNames = new string[teamSize];
            ShowResult show = null;
            do
            {
                Console.Clear();
                Menu();
                try
                {
                    Console.WriteLine("Gör ett val.");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1: 
                            teamName = Console.ReadLine().ToLower();
                            

                            Register register = new Register(char.ToUpper(teamName[0]) + teamName.Substring(1));
                            
                            
                            if (register.check(teamNames) == true)
                            {
                                Console.WriteLine("inte lika");
                                teamNames[c] = char.ToUpper(teamName[0]) + teamName.Substring(1);                              
                                
                                for (i = 1; i < 6; i += 1)
                                {
                                    memberNames[i-1] = ReadMemberNames("Ange lagmedlem " + i + ": ");
                                    AllMembers[c, i-1] = memberNames[i-1];
                                }                              

                                show = new ShowResult(teamNames, AllMembers);
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

                        case 2:
                            if (show != null)
                            {
                                Console.Clear();
                                TeamShowMenu();
                                
                                for (i = 0; i < teamNames.Length; i += 1)
                                {
                                    if (teamNames[i] == null)
                                    {
                                        break;
                                    }
                                    Console.WriteLine("Lag {0}: {1}", i+1, teamNames[i]);
                                    for (j = 1; j < 6; j += 1)
                                    {                                   
                                        Console.WriteLine("     Medlem {0}: {1}", j, AllMembers[i, j-1]);
                                    }
                                }
                                int input = int.Parse(Console.ReadLine());
                                if (input == -1)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lag {0}: {1}", input, teamNames[input -1]);
                                    for (j = 1; j < 6; j += 1)
                                    {
                                        Console.WriteLine("     Medlem {0}: {1}", j, AllMembers[input-1, j - 1]);
                                    }
                                }
                                
                            }
                            else 
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Inget lag har registrerats ännu.");
                                Console.ResetColor();
                            }
                            
                            break;
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ett fel hände.");
                    Console.ResetColor();
                }



            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            
        }
        static void Menu()
        {
            Console.WriteLine("Val:");
            Console.WriteLine("1. Registrera.");
            Console.WriteLine("2. Kolla anmälda lag.");
        }

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

        static string ReadMemberNames(string promt)
        {
            

            while (true)
            {
                Console.Write(promt);
                string input = Console.ReadLine();
                if (input == "")
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
    }
}
