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
                    if (_userBudget != null)
                    {
                        _userBudget.DisplaySummary();
                    } else 
                    {
                        Console.WriteLine("Please create a budget first");
                    }
                    break;
                case 3:
                    AddTransaction();
                    break;
                case 4:
                    _userBudget.DisplayTransactionsByCategory();
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
                } else 
                {
                    Console.WriteLine("Your budget is complete!");
                    userAddingCategory = 'n';
                }
            }
        }
        if (balance > 0)
        {
            _userBudget.AddCategory("Extra", "Unplanned expenses", balance);
        }

        Console.WriteLine("Budget created!");
    }

    public void AddTransaction()
    {
        Console.WriteLine("");
        Console.Write("Is this an expense transaction? (y/n): ");
        string str = Console.ReadLine();
        char userInput = str.ToCharArray()[0];
        Transaction userTransaction;

        Console.WriteLine("Indicate the following:");
        Console.WriteLine("");
        Console.Write("Name of transaction: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Amount: ");
        string strAmount = Console.ReadLine();
        double amount = double.Parse(strAmount);

        if (userInput == 'y')
        {
            Console.Write("From the following Categories: ");
            _userBudget.DisplayCategories();
            Console.Write("In which Category number would this transaction fit into?: ");
            string catIndexStr = Console.ReadLine();
            int catIndex = int.Parse(catIndexStr);
            var categories = _userBudget.GetCategoryList();
            string catName = categories[catIndex - 1].GetCategoryName();

            userTransaction = new ExpenseTransaction(name, description, amount, catName);
        } else 
        {
            userTransaction = new IncomeTransaction(name, description, amount);
        }
        
        _userBudget.AddTransaction(userTransaction);
    }

    public void SaveBudgetToFile()
    {
        _fileManager.SaveToFile(_userBudget);
    }
    public void LoadBudgetFromFile()
    {
        _userBudget = _fileManager.LoadFromFile();
    }
}