using System;

class Program
{
    static void Main(string[] args)
    {
        // key flags
        string userInput = " ";
        bool scriptureIsHidden = false;
        Random randomGenerator = new Random();
        int numberOfWordsToHide;
        int hiddenWords = 0;
        
        // Logic to bring scriptures from the json file
        string jsonFilePath = "scriptures.json";
        JsonLoader dataLoader = new JsonLoader(jsonFilePath);
        List<Scripture> scriptureList = dataLoader.GetScriptureList();

        int randomScriptureIndex = randomGenerator.Next(0, scriptureList.Count);
        Scripture myScripture = scriptureList[randomScriptureIndex];
        
        // main program run
        while (!scriptureIsHidden && userInput != "quit") 
        {
            Console.Clear();
            string textDisplay = myScripture.GetDisplayText();
            Console.WriteLine(textDisplay);
            Console.WriteLine();

            hiddenWords = myScripture.GetAmountOfHiddenWords();
            string resetOption = hiddenWords > 0 ? ", type 'reset' to start again " : " ";
            Console.WriteLine($"Press enter to continue{resetOption}or type 'quit' to finish:");

            userInput = Console.ReadLine()?.Trim();
            if (userInput != "quit") {

                // add a restart method to let the user begin again
                if (userInput.Equals("reset"))
                {
                    myScripture.RestartScripture();
                }
                else 
                {
                    numberOfWordsToHide = randomGenerator.Next(1, 5);
                    myScripture.HideRandomWords(numberOfWordsToHide);
                    scriptureIsHidden = myScripture.isCompletelyHidden();
                }
            }

        }
        Console.WriteLine("Game Finished");


    }
}