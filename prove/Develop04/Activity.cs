public class Activity 
{
    private string _name;
    private string _description;
    private int _duration;
    private int _countLog;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
        _countLog = 0;
    }

    public void DisplayStartingMessage() 
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine($"\n{_description}\n");

        Console.Write("How long, in seconds, would you like for your session? ");
        string sessionSeconds = Console.ReadLine();
        _duration = int.Parse(sessionSeconds);

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
    }
    public void DisplayEndingMessage() 
    {
        Console.WriteLine("Well done!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}");
        ShowSpinner(5);
    }
    public void ShowSpinner(int seconds) 
    {
        List<string> animationCharaters = new List<string>
        {
            "|", "/", "-", "|", "\\"
        };
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);

        int idx = 0;

        while(DateTime.Now < futureTime)
        {
            string s = animationCharaters[idx];
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");

            idx++;
            if (idx >= animationCharaters.Count)
            {
                idx = 0;
            }
        }
    }
    public void ShowCountDown(int seconds) 
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    public DateTime GetActivityEndTime() 
    {
        DateTime currentTime = DateTime.Now;
        DateTime futureTime = currentTime.AddSeconds(_duration);
        
        return futureTime;
    }

    public void AddToCountLog()
    {
        _countLog++;
    }

    public void DisplayCountLog()
    {
        Console.WriteLine($" {_name}:\t{_countLog}");
    }

}