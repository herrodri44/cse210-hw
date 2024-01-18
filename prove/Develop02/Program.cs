using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");
        string userInput;
        int numericInput = 0;
        Journal userJournal = new Journal();
        PromptGenerator prompt = new PromptGenerator();

        void HandleUserInput(int option)
        {
            if (option == 1)
            {
                string randomPrompt = prompt.ChooseRandom();
                Console.WriteLine(randomPrompt);
                string answer = Console.ReadLine();
                userJournal.AddEntry(randomPrompt, answer);
            }
            if (option == 2)
            {
                userJournal.DisplayEntries();
            }
            if (option == 3)
            {
                Console.WriteLine("What is the file name?");
                string fileName = Console.ReadLine();
                userJournal.LoadFile(fileName);
            }
            if (option == 4)
            {
                Console.WriteLine("What is the file name?");
                string fileName = Console.ReadLine();
                userJournal.SaveFile(fileName);
            }
            if (option == 5)
            {
                return;
            }
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
            
            userInput = Console.ReadLine();
            numericInput = int.Parse(userInput);
            
            HandleUserInput(numericInput);
        } while (numericInput  != 5);
    }
}