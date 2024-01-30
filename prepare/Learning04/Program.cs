using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment baseASsignment = new Assignment("Samuel Bennett", "Multiplication");
        MathAssignment math = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        WritingAssignment writing = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");

        
        Console.WriteLine(baseASsignment.GetSummary());
        Console.WriteLine();

        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());
        Console.WriteLine();
        
        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
    }   
}