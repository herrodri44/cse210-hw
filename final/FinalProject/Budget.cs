public class Budget
{
    private double _income;
    private List<Category> _categories = new List<Category>();
    private List<Transaction> _transactions = new List<Transaction>();

    public Budget(double income)
    {
        _income = income;
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
        Console.WriteLine($"Total spent:    \t{_income - spent}");
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

    public void AddTransaction()
    {
        Console.WriteLine("not implemented yet");
    }
    public void DisplayTransactionsByCategory()
    {
        Console.WriteLine("not implemented yet");
    }
}