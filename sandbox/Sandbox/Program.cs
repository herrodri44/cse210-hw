using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");
        char[] myValidOptions = {'0','1','2'};

        Console.WriteLine(myValidOptions.Contains('2'));
        Console.WriteLine(myValidOptions.Contains('F'));
    }
}