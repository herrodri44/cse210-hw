
public abstract class Goal
{
        protected string _shortName;
        protected string _description;
        protected int _points;

        public Goal(string shortName, string description, int points)
        {
            _shortName = shortName;
            _description = description;
            _points = points;
        }

        public Goal(string shortName, string description, string points)
        {
            _shortName = shortName;
            _description = description;
            _points = int.Parse(points);
        }

        public abstract int RecordEvent();
        public abstract bool IsComplete();
        public virtual string GetDetailsString() 
        {
            char completeMark = IsComplete() ? 'X' : ' ';
            return $"[{completeMark}] {_shortName} ({_description})";
        }
        public abstract string GetStringRepresentation();

        public string GetGoalName()
        {
            return _shortName;
        }
}