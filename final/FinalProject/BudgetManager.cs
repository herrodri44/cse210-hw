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
        Console.WriteLine("");
        Console.Write("Enter your initial income: ");
        string userIncome = Console.ReadLine();
        double income = int.Parse(userIncome);
        double balance = double.Parse(userIncome);

        _userBudget = new Budget(income);
        Console.WriteLine("");
        char userAddingCategory = 'y';

        while(userAddingCategory == 'y')
        {
            Console.Write("Add a category to your budget? (y/n): ");
            
            string str = Console.ReadLine();
            userAddingCategory = str.ToCharArray()[0];
            if (userAddingCategory == 'y')
            {
                Console.WriteLine("Please provide the following information");
                Console.Write("");
                Console.Write("Category Name: ");
                string name = Console.ReadLine();
                // Console.Write("");
                Console.Write("Category description: ");
                string description = Console.ReadLine();
                // Console.Write("");
                Console.Write("Amount allocated for this category: ");
                string amount = Console.ReadLine();
                double categoryAmount = double.Parse(amount);
                _userBudget.AddCategory(name, description, categoryAmount);
                
                balance = balance - categoryAmount;
                Console.WriteLine("");
                if (balance > 0)
                {
                    Console.WriteLine($"You still have {balance} in your budget");
                    Console.WriteLine("If you don't create another category, this will be added to an 'Extras' category.");
                }
            }
        }
        if (balance > 0)
        {
            _userBudget.AddCategory("Extra", "Unplanned expenses", balance);
        }

        Console.WriteLine("Budget created!");
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