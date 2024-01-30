
public class WritingAssignment: Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }


    // Section 7.3 Problems 8-19
    public string GetWritingInformation()
    {
        return $"{_title} by {GetStudentName()}";
    }
}