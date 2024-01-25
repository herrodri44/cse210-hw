using System;

class Program
{
    static void Main(string[] args)
    {
        // Setup
        Reference scriptureReference = new Reference("John", 13, 34);
        Scripture myScripture = new Scripture(
            scriptureReference, 
            "A new commandment I give unto you, That ye love one another; as I have loved you, that ye also love one another."
        );

        // key flags
        string userInput = " ";
        bool scriptureIsHidden = false;
        Random randomGenerator = new Random();
        int numberOfWordsToHide;
        
        // main program run
        while (!scriptureIsHidden && userInput != "quit") 
        {
            Console.Clear();
            string textDisplay = myScripture.GetDisplayText();
            Console.WriteLine(textDisplay);
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            
            userInput = Console.ReadLine()?.Trim();;
            if (userInput != "quit") {
                numberOfWordsToHide = randomGenerator.Next(1, 5);
                myScripture.HideRandomWords(numberOfWordsToHide);
                scriptureIsHidden = myScripture.isCompletelyHidden();
            }

        }
        Console.WriteLine("Game Finished");


    }
}