using System;

class Program
{
    static void Main(string[] args)
    {
        string _userInput;
        int _userOption = 0;
        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectingActivity reflectingActivity = new ReflectingActivity();
        ListingActivity listingActivity = new ListingActivity();

        while (_userOption != 4)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("\t1. Start breating activity");
            Console.WriteLine("\t2. Start reflecting activity");
            Console.WriteLine("\t3. Start listing activity");
            Console.WriteLine("\t4. Quit");
            Console.WriteLine("Select a choice from the menu: ");

            _userInput = Console.ReadLine();
            _userOption = int.Parse(_userInput);

            switch(_userOption) 
            {
                case 1:
                    breathingActivity.Run();
                    break;
                case 2:
                    reflectingActivity.Run();
                    break;
                case 3:
                    listingActivity.Run();
                    break;
                case 4:
                    Console.WriteLine("Thanks for playing");
                    break;
                default:
                    Console.WriteLine("Make sure you select an option from 1 to 4");
                    break;
            }
        }

        
    }
}