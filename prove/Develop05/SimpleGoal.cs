public class SimpleGoal : Goal
{
    private bool _isCompleted;

    public SimpleGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
        _isCompleted = false;
    }
    // To use when we load from a file
    public SimpleGoal(string shortName, string description, int points, bool isComplete) : base(shortName, description, points)
    {
        _isCompleted = isComplete;
    }
    public override int RecordEvent() 
    {
        if (_isCompleted)
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