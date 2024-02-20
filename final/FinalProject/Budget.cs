public class Budget
{
    private double _income;
    private List<Category> _categories = new List<Category>();
    private List<Transaction> _transactions = new List<Transaction>();

    public Budget(double income)
    {
        _income = income;
    }
    public Budget()
    {
        _income = 0;
    }

    public double GetIncome() 
    {
        return _income;
    }
    public void SetIncome(double income) 
    {
        _income = income;
    }

    public List<Category> GetCategoryList()
    {
        return _categories;
    }

    public List<Transaction> GetTransactionList()
    {
        return _transactions;
    }
    
    public void AddCategory(string name, string description, double amount)
    {
        Category category = new Category(name, description, amount);
        _categories.Add(category);
    }

    public void DisplaySummary()
    {
        double spent = GetBalance();

        Console.WriteLine($"Initial Balance:\t{_income}");
        Console.WriteLine($"Total spent:    \t{spent}");
        Console.WriteLine($"Total spent:    \t{_income + spent}");
        // show spending by category
        Console.WriteLine("");
    }

    private double GetBalance()
    {
        double balanceModification = 0; 
        foreach (var item in _transactions)
        {
            if (item.IsExpense())
            {
                balanceModification = balanceModification - item.GetTransactionAmount();
            } else 
            {
                balanceModification = balanceModification + item.GetTransactionAmount();
            }
        }
        return balanceModification;
    }

    public void AddTransaction(Transaction transaction)
    {   
        _transactions.Add(transaction);
    }

    public void DisplayTransactionsByCategory()
    {
        Console.Write("From the following Categories: ");
        DisplayCategories();
        Console.Write("What category transactions would you like to review?: ");
        string catIndexStr = Console.ReadLine();
        int catIndex = int.Parse(catIndexStr);
        string catName = _categories[catIndex - 1].GetCategoryName();

        int amountOfTransactions = 0;
        if (_transactions.Count == 0)
        {
            Console.WriteLine("There are no transactions to show");
        }
        foreach (Transaction item in _transactions)
        {
            if (item.IsExpense())
            {
                ExpenseTransaction expenseTransaction = (ExpenseTransaction)item;
                string transactionCategory = expenseTransaction.GetCategoryName();
                if (String.Equals(transactionCategory, catName))
                {
                    amountOfTransactions++;
                    string details = expenseTransaction.GetStringDetails();
                    Console.WriteLine($"\t{amountOfTransactions} - {details}");
                }
            }
        }
        if (amountOfTransactions == 0)
        {
            Console.WriteLine("There are no transactions for this category");
        }
    }

    public void DisplayCategories()
    {
        Console.WriteLine("");
        int index = 1;
        foreach (var item in _categories)
        {
            Console.WriteLine($"\t{index} - {item.GetCategoryName()}");
            index++;
        }
    }

    public List<string> GetStringRepresentations()
    {
        List<string> representationList = new List<string>();
        
        foreach (Category cat in _categories)
        {
            representationList.Add(cat.GetStringRepresentation());
        }
        foreach (Transaction tran in _transactions)
        {
            representationList.Add(tran.GetStringRepresentation());
        }

        return representationList;
    }
}