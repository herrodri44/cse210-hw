public class BudgetManager
{
    private Budget _userBudget;
    private FileManager _fileManager;

    public BudgetManager()
    {
        _fileManager = new FileManager();
    }

    public void Start()
    {
        int userOption = 0;
        string userInput;
        Console.WriteLine("------ Budget Manager ------");

        while (userOption != 7)
        {
            userOption = 0;

            Console.WriteLine("Options:");
            Console.WriteLine("\t1. Create Budget");
            Console.WriteLine("\t2. Check the current Budget Summary");
            Console.WriteLine("\t3. Add transaction");
            Console.WriteLine("\t4. Check Transactions details");
            Console.WriteLine("\t5. Save Budget");
            Console.WriteLine("\t6. Load Budget");
            Console.WriteLine("\t7. Quit");

            Console.WriteLine("");
            Console.Write("Select a choice from the menu: ");
            userInput = Console.ReadLine();
            int t = 0;
            if(int.TryParse(userInput.Trim(), out t)) 
            {
                userOption = int.Parse(userInput.Trim());
            }

            switch (userOption)
            {
                case 1:
                    CreateBudget();
                    break;
                case 2:
                    _userBudget.DisplaySummary();
                    break;
                case 3:
                    _userBudget.AddTransaction();
                    break;
                case 4:
                    CheckTransactionDetails();
                    break;
                case 5:
                    SaveBudgetToFile();
                    break;
                case 6:
                    LoadBudgetFromFile();
                    break;
                case 7:
                    break;
                default:
                    Console.WriteLine("Please select an option from the menu (1-7)");
                    break;
            }

        }
    }

    public void CreateBudget()
    {
        Console.WriteLine("Creating budget...");
        _userBudget = new Budget(100);
    }

    public void CheckTransactionDetails()
    {
        Console.WriteLine("Check Transaction Details...");
    }
    public void SaveBudgetToFile()
    {
        Console.WriteLine("Check Transaction Details...");
    }
    public void LoadBudgetFromFile()
    {
        Console.WriteLine("Check Transaction Details...");
    }
}