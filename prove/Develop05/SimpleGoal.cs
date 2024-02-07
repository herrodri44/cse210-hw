public class SimpleGoal : Goal
{
    private bool _isCompleted;

    public SimpleGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
        _isCompleted = false;
    }
    public override void RecordEvent() {}
    public override bool IsComplete() {}
    public override string GetStringRepresentation() {}

}