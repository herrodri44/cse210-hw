public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
    };
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "What could you learn from this experience that applies to other situations?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
    };

    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") {}

    public void Run() 
    {
        DisplayStartingMessage();
        Console.WriteLine("Consider the following prompt:");
        DisplayPrompt();
        Console.WriteLine("When you have something in your mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder in each of the following questions as they relate to this experience.");
        Console.Write("\nYou may begin in... ");
        ShowCountDown(5);

        Console.Clear();
        DateTime endTime = GetActivityEndTime();
        
        while (DateTime.Now < endTime)
        {
            DisplayQuestion();
        }
        DisplayEndingMessage();
        AddToCountLog();
    }

    public string GetRandomPrompt() 
    {
        Random randomGenerator = new Random();
        int idx = randomGenerator.Next(0, _prompts.Count);
        return _prompts[idx];
    }

    public string GetRandomQuestion() 
    {
        Random randomGenerator = new Random();
        int idx = randomGenerator.Next(0, _questions.Count);
        return _questions[idx];
    }

    public void DisplayPrompt() 
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($" --- {prompt}");
    }

    public void DisplayQuestion() 
    {
        string question = GetRandomQuestion();
        Console.Write($"\n {question} ");
        ShowSpinner(8);
        Console.WriteLine();
    }
}