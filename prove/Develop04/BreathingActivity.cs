public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        DateTime endTime = GetActivityEndTime();
        
        while (DateTime.Now < endTime) 
        {
            Console.Write("\nBreath in ");
            ShowCountDown(4);
            Console.Write("\nNow breath out ");
            ShowCountDown(4);
            Console.WriteLine();
        }
        
        DisplayEndingMessage();
        AddToCountLog();
    }
}