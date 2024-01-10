using System;

class Program
{
    static void Main(string[] args)
    {
        /* What is your first name? Scott
        What is your last name? Burton

        Your name is Burton, Scott Burton. */
        Console.Write("What is your first name?");
        string firstName = Console.ReadLine();
        Console.Write("What is your last name?");
        string lastName = Console.ReadLine();

        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}