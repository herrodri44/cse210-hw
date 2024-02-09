using System.IO; 

public class GoalManager
{
    private List<Goal> _goalList = new List<Goal>();
    private int _score;

    public GoalManager()
    {
        _score = 0;
    }

    public void Start() 
    {
        // This is the "main" function for this class. It is called by Program.cs, and then runs the menu loop.
        int userOption = 0;

        while (userOption != 6)
        {
            DisplayPlayerInfo();
            Console.WriteLine("");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("\t1. Create New Goal");
            Console.WriteLine("\t2. List Goals");
            Console.WriteLine("\t3. Save Goal");
            Console.WriteLine("\t4. Load Goal");
            Console.WriteLine("\t5. Record Event");
            Console.WriteLine("\t6. Quit");
            Console.WriteLine("");
            Console.Write("Select a choice from the menu: ");
            string userInput = Console.ReadLine();
            int t = 0;
            if(int.TryParse(userInput.Trim(), out t)) 
            {
                userOption = int.Parse(userInput.Trim());
            }
            switch (userOption)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveToFile();
                    break;
                case 4:
                    LoadFromFile();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("Please select an option from the menu (1-6)");
                    break;
            }
        }

    }
    public void DisplayPlayerInfo() 
    {
        // Displays the players current score
        Console.WriteLine($"You have {_score} points");
    }
    public void ListGoalNames() 
    {
        int index = 1;
        Console.WriteLine("The goals are: ");
        foreach (Goal goal in _goalList)
        {
            Console.WriteLine($"{index}. {goal.GetGoalName()}");
            index++;
        }
    }
    public void ListGoalDetails() 
    {
        if (_goalList.Count == 0)
        {
            Console.WriteLine("There are no current goals. Add one through the menu to see them in this section.");
            return;
        }
        // Lists the details of each goal (including the checkbox of whether it is complete).
        // used to list all the goals
        int index = 1;
        Console.WriteLine("The goals are: ");
        foreach (Goal goal in _goalList)
        {
            Console.WriteLine($"{index}. {goal.GetDetailsString()}");
            index++;
        }
    }
    public void CreateGoal() 
    {
        // Asks the user for the information about a new goal. Then, creates the goal and adds it to the list.
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("\t1. Simple Goal");
        Console.WriteLine("\t2. Eternal Goal");
        Console.WriteLine("\t3. Checklist Goal");
        Console.WriteLine("");

        Console.Write("What type of goal would you like to create?: ");
        string goalOption = Console.ReadLine();
        int goalType = int.Parse(goalOption);

        Console.WriteLine("");
        Console.Write("What is the name of your goal? ");
        string goalName = Console.ReadLine();
        Console.Write("What is a short description? ");
        string goalDescription = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int goalPoints = int.Parse(Console.ReadLine());

        Goal newGoal;
        if (goalType == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int goalTarget = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int goalBonus = int.Parse(Console.ReadLine());

            newGoal = new ChecklistGoal(goalName, goalDescription, goalPoints, goalTarget, goalBonus);
        } else if (goalType == 2)
        {
            newGoal = new EternalGoal(goalName, goalDescription, goalPoints);
        } else 
        {
            newGoal = new SimpleGoal(goalName, goalDescription, goalPoints);
        }

        _goalList.Add(newGoal);
    }

    public void RecordEvent() 
    {
        if (_goalList.Count == 0)
        {
            Console.WriteLine("There are no goals in the list. Please create a goal first to record an event.")
            return;
        }
        // Asks the user which goal they have done and then records the event by calling the RecordEvent method on that goal
        ListGoalNames();
        
        Console.WriteLine("");
        Console.Write("Which goal did you accomplish? ");
        string userInput = Console.ReadLine();
        int goalIndex = int.Parse(userInput) - 1;

        Console.WriteLine($"Recording Event for {_goalList[goalIndex].GetGoalName()}");

        int pointsObtained = _goalList[goalIndex].RecordEvent();
        _score = _score + pointsObtained;

        Console.WriteLine($"You now have {_score} points.");
    }
    public void SaveToFile() 
    {
        Console.WriteLine("");
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine($"Score|{_score}");
            foreach (Goal goal in _goalList)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }
    public void LoadFromFile() 
    {
        Console.WriteLine("");
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(fileName);
        int idx = 1;
        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            Goal newGoal;
            switch (parts[0])
            {
                case "Score":
                    _score = int.Parse(parts[1]);
                    break;
                case "SimpleGoal":
                    //  $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isCompleted}";
                    newGoal = new SimpleGoal(parts[1], parts[2], parts[3], parts[4]);
                    _goalList.Add(newGoal);
                    break;
                case "EternalGoal":
                    //  $"EternalGoal|{_shortName}|{_description}|{_points}"
                    newGoal = new EternalGoal(parts[1], parts[2], parts[3]);
                    _goalList.Add(newGoal);
                    break;
                case "ChecklistGoal":
                    //  $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_bonus}|{_target}|{_amountCompleted}";
                    newGoal = new ChecklistGoal(parts[1], parts[2], parts[3], parts[4],parts[5],parts[6]);
                    _goalList.Add(newGoal);
                    break;
                default:
                    Console.WriteLine($"Unable to read line {idx}");
                    break;
            }
            idx++;
        }
    }
}