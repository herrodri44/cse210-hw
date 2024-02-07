
public class Goal
{
        protected string _ShortName;
        protected string _description;
        protected int _points;

        public Goal(string shortName, string description, int points)
        {

        }

        public virtual void RecordEvent() {}
        public virtual bool IsComplete() {}
        public string GetDetailsString() {}
        public virtual string GetStringRepresentation() {}

}