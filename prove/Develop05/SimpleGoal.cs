public class SimpleGoal : Goal
{
    private bool _isCompleted;

    public SimpleGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
        _isCompleted = false;
    }
    // To use when we load from a file
    public SimpleGoal(string shortName, string description, string points, string isComplete) : base(shortName, description, points)
    {
        _isCompleted = isComplete == "True";
    }
    public override int RecordEvent() 
    {
        if (IsComplete())
        {
            Console.WriteLine("You have already completed this goal.");
            return 0;
        }

        Console.WriteLine($"Congratulations! You have earned {_points} points!");
        _isCompleted = true;
        return _points;
    }
    public override bool IsComplete() 
    {
        return _isCompleted;
    }
    public override string GetStringRepresentation() 
    {
        return $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isCompleted}";
    }

}