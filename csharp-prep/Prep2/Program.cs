using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a grade percentage: ");
        string grade = Console.ReadLine();
        int numberGrade = int.Parse(grade);
        char letter;
        bool pass = true;
        char sign = ' ';

        if (numberGrade >= 90)
        {
            letter = 'A';
        }
        else if (numberGrade >= 80)
        {
            letter = 'B';
        }
        else if (numberGrade >= 70)
        {
            letter = 'C';
        }
        else if (numberGrade >= 60)
        {
            letter = 'D';
            pass = false;
        }
        else
        {
            letter = 'F';
            pass = false;
        }

        
        if (numberGrade % 10 >= 7)
        {
            sign = '+';
        } else if (numberGrade % 10 < 3) 
        {
            sign = '-';
        }

        if (numberGrade < 60 || numberGrade >= 97)
        {
            sign = ' ';
        }

        string message = "You failed this class. Better luck next time.";
        if (pass) 
        {
            message = "You passed this class. Congratulations!";
        }
        Console.WriteLine($"Your letter grade is: {letter}{(sign != ' ' ? sign.ToString() : "")}. {message}");

    }
}