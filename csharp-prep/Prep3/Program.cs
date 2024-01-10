using System;

class Program
{
    static void Main(string[] args)
    {

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);
        string userInputGuess;
        int guess;
        int attempts  = 0;
        
        do
        {
            Console.Write("What is your guess? ");
            userInputGuess = Console.ReadLine();
            guess = int.Parse(userInputGuess);
            attempts = attempts + 1;

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            } else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            } else 
            {
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"Answer found in {attempts} attempts");
            }

        } while (magicNumber != guess);
        
    }
}