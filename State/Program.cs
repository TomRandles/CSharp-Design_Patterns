using State.ApplianceStateManagement;
using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the appliance state management demo!!");
            Console.WriteLine("*************************************************");
            Console.WriteLine();
            Console.WriteLine("Appliance state management instructions");
            Console.WriteLine("\tTurn on appliance: \'n\'");
            Console.WriteLine("\tTurn of appliance: \'o\'");
            Console.WriteLine("\tStart appliance programme: \'s\'");
            Console.WriteLine("\tStop appliance programme: \'t\'");
            Console.WriteLine("\tQuit: \'q\' \n\n");

            ApplianceContext applianceContext = new ApplianceContext("DA0056", "Heat Pump");

            // Get current appliance default state
            // Console.WriteLine($"Current appliance state: \"{applianceContext.ShowCurrentState()}\"");

            string input;
            do
            {
                Console.Write("\nEnter state change request: ");
                input = Console.ReadLine();
                input = input.ToLower();
                switch (input)
                {
                    case "o":
                        applianceContext.TurnApplianceOff();
                        break;

                    case "n":
                        applianceContext.TurnApplianceOn();
                        break;

                    case "s":
                        applianceContext.StartApplianceProgramme();
                        break;

                    case "t":
                        applianceContext.StopApplianceProgramme();
                        break;

                    case "q":
                        applianceContext.TurnApplianceOff();
                        break;

                    default:
                        Console.WriteLine($"Unrecognised command: {input}");
                        break;
                }

            } while (input != "q");
            Console.WriteLine("Bye ...");
        }
    }
}
