public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus) : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }
    // To use when we load from a file
    public ChecklistGoal(string shortName, string description, int points, int target, int bonus, int amount) : base(shortName, description, points)
    {
        _amountCompleted = amount;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent() 
    {
        if (_amountCompleted == _target)
        {
            Console.WriteLine("You have already completed this goal.");
            return 0;
        }
        int pointsObtained = _points;
        if (_amountCompleted == _target - 1)
        {
            pointsObtained = pointsObtained + _bonus;
        }
        Console.WriteLine($"Congratulations! You have earned {pointsObtained} points!");
        _amountCompleted++;
        return pointsObtained;
    }

    public override bool IsComplete() 
    {
        return _amountCompleted == _target;
    }
    public override string GetDetailsString() 
    {
        char completeMark = IsComplete() ? 'X' : ' ';
        return $"[{completeMark}] {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }
    public override string GetStringRepresentation() 
    {
        return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_bonus}|{_target}|{_amountCompleted}";
    }

}