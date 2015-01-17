using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnasticCompetitionProject
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterCheck registerCheck = new RegisterCheck();
            LoggIn loggin = null;
            Editor editor = new Editor();
            int teamNumber = 0;
            string[] teamNamesUpdater;
            int checker = -1;
            bool loggedIn = false;
            do
            {
                Console.Clear();
                if (loggedIn == false)
                {
                    LoggedOutMenu();
                }
                else
                {
                    LoggedInMenu();
                }

                //Iteration1Tests Testare = new Iteration1Tests();
                //Testare.testOne(); - Lyckat.
                //Testare.testTwo(); - Lyckat.
                //Testare.testThree(); - Lyckat. // Misslyckat, kan registrear 2 lag som har samma namn med olika gemener/ versaler
                //Testare.testFour(); - Lyckat.

                //Iteration2Tests testareTwo = new Iteration2Tests();
                //testareTwo.TestOne(); // - Lyckat
                //testareTwo.TestTwo();// - Lyckat // testar att lägga till 5 poäng till 3 medlemmar och sen resetta en av deras poäng till 0, uppdatering ska ske 5, 10, 15, 10.
                //testareTwo.TestThree(); // - Lyckat
                //testareTwo.TestFour(); // - Acceptabelt, skillnaden är om man skriver in 3, så körs en Console.Clear(), ist om man t ex. skriver in 10 så körs ingen Console.Clear();

                //Iteration3Tests Testare = new Iteration3Tests();
                //Testare.TestOne(); // testas manuellt
                //Testare.TestTwo(); // test misslyckat 1 gång, fanns inget som kollade om några lag har blivit tilldelade poäng än.
                // andra försök: test nu lyckat, har en boolean som kollar om ett lag än fått poäng.
                //Testare.TestThree(); // testas manuellt.
                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 0: return;

                        case 1:
                            Console.Clear();
                            teamNumber = registerCheck.teamRegister() - 1;
                            if (teamNumber != checker)
                            {
                                // om teamNumber skiljer sig ifrån checker så är namnet inte registrerat.
                                editor.ReadMemberNames(teamNumber);
                                checker = teamNumber;
                            }                                                                                  
                            break;

                        case 2:
                            Console.Clear();
                            if (checker == -1)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Inga lag har registrerats ännu.");
                                Console.ResetColor();
                            }
                            else 
                            {
                                editor.DisplayTeamOrder(registerCheck.getTeamNames());
                            }                           
                            break;

                        case 3:
                            Console.Clear();
                            if (loggedIn == false)
                            {
                                Console.WriteLine("Vänligen ange ett tal inom meny valen.");
                            }
                            else if (checker != -1)
                            {
                                editor.ChangeMemberPoints(registerCheck.getTeamNames());                             
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Inga lag har registrerats ännu.");
                                Console.ResetColor();
                            }
                            break;


                        case 4: 
                            Console.Clear();
                            if (loggedIn == false)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Vänligen ange ett tal inom meny valen.");
                                Console.ResetColor();
                            }
                            // om checker har fått ett värde annat än -1 så betyder det att en lag registrering har gått igenom.
                            else if (checker != -1)
                            {
                                teamNamesUpdater = editor.ChangeNames(registerCheck.getTeamNames());
                                registerCheck.setTeamNames(teamNamesUpdater);
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Inga lag har registrerats ännu.");
                                Console.ResetColor();
                            }
                            break;

                        case 5:
                            Console.Clear();
                            
                            if (loggedIn == true)
                            {
                                Console.WriteLine("Du har nu loggats ut.");
                                loggedIn = false;
                            }
                            else if (loggedIn == false)
                            {                               
                                loggin = new LoggIn();
                                loggedIn = loggin.ValidateInfo();
                            }
                            break;
                        default:
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Vänligen ange ett tal inom meny valen.");
                            Console.ResetColor();
                            break;
                            
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ett fel uppstod.");
                    Console.ResetColor();
                }

                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Tryck valfri tangent för att gå tillbaka till huvud menyn - ESC avslutar.");
                Console.ResetColor();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            
        }

        static void LoggedOutMenu()
        {           
            Console.WriteLine("__________________");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("|                |");
            Console.WriteLine("|    Huvudmeny   |");
            Console.WriteLine("|________________|");
            Console.ResetColor();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Du inte inloggad.");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Val:");
            Console.WriteLine("0. Avsluta.");
            Console.WriteLine("1. Registrera ett lag.");
            Console.WriteLine("2. Se alla lag i poängordning.");
            Console.WriteLine();
            Console.WriteLine("5. Logga in.");
            Console.WriteLine();
            Console.Write("Ange ditt val: ");
        }

        static void LoggedInMenu()
        {           
            Console.WriteLine("__________________");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("|                |");
            Console.WriteLine("|    Huvudmeny   |");
            Console.WriteLine("|________________|");
            Console.ResetColor();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Du är inloggad.");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Val:");
            Console.WriteLine("0. Avsluta.");
            Console.WriteLine("1. Registrera ett lag.");
            Console.WriteLine("2. Se alla lag i poängordning.");
            Console.WriteLine("3. Lägg till/ ändra deltagandes poäng.");
            Console.WriteLine("4. Editera alla lag.");
            Console.WriteLine("5. Logga ut.");
            Console.WriteLine();
            Console.Write("Ange ditt val: ");
        }
    }
}
