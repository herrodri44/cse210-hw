public class ListingActivity : Activity 
{
    private List<string> _prompts = new List<string> 
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void Run() 
    {
        DisplayStartingMessage();
        Console.WriteLine("List as many responses you can to the following prompt:");
        GetRandomPrompt();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        DateTime endTime = GetActivityEndTime();
        List<string> list = new List<string>();
        
        while (DateTime.Now < endTime) 
        {
            Console.Write("> ");
            string userEntry = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(userEntry))
            {
                list.Add(userEntry);
            }
        }

        Console.WriteLine($"You listed {list.Count} items!");
        DisplayEndingMessage();
        AddToCountLog();
    }
    public void GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int idx = randomGenerator.Next(0, _prompts.Count);
        string prompt = _prompts[idx];

        Console.WriteLine($" --- {prompt} ---");
    }
}