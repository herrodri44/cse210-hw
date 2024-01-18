using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");
        int userInput;
        string fileName;
        Journal userJournal = new Journal();
        PromptGenerator prompt = new PromptGenerator();

        void HandleUserOption(int option)
        {
            switch(option) 
            {
                case 1:
                    string randomPrompt = prompt.ChooseRandom();
                    Console.WriteLine(randomPrompt);
                    string answer = Console.ReadLine();
                    userJournal.AddEntry(randomPrompt, answer);
                    break;
                case 2:
                    userJournal.DisplayEntries();
                    break;
                case 3:
                    Console.WriteLine("What is the file name?");
                    fileName = Console.ReadLine();
                    userJournal.LoadFile(fileName);
                    break;
                case 4:
                    Console.WriteLine("What is the file name?");
                    fileName = Console.ReadLine();
                    userJournal.SaveFile(fileName);
                    break;
                case 5:
                    Console.WriteLine("Thanks for recording your thoughts comments");
                    break;
                default:
                    // this can help cover the case when a user outside the options
                    Console.WriteLine("Make sure you select an option from 1 to 5");
                    break;
            }
        }

        int HandleUserInput()
        {
            string stringInput = Console.ReadLine();
            int numericInput = int.Parse(stringInput);
            return numericInput;
        }

        do
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            userInput = HandleUserInput();
            
            HandleUserOption(userInput);
        } while (userInput  != 5);
    }
}