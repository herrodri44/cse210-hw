using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        string userInput;
        int userInputNumber;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do
        {
            Console.WriteLine("Enter number: ");
            userInput = Console.ReadLine();
            userInputNumber = int.Parse(userInput);
            numbers.Add(userInputNumber);

        } while (userInputNumber != 0);

        int numbersSum = 0;
        int numbersLargest = numbers[0];
        float numbersAverage;
        
        
        foreach (int number in numbers)
        {
            numbersSum = numbersSum + number;
            if (number > numbersLargest)
            {
                numbersLargest = number;
            }
        }

        numbersAverage = numbersSum / numbers.Count;

        Console.WriteLine($"The sum is: {numbersSum}");
        Console.WriteLine($"The average is: {numbersAverage}");
        Console.WriteLine($"The largest number is: {numbersLargest}");
    }
}