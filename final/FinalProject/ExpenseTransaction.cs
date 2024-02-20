public class ExpenseTransaction : Transaction
{
    private string _categoryName;
    public ExpenseTransaction(string name, string description, double amount, string categoryName) : base(name, description, amount)
    {
        _categoryName = categoryName;
        _isExpense = true;
    }

    //  $"ExpenseTransaction|{_name}|{_amount}|{_description}|{_date}|{_categoryName}"
    public ExpenseTransaction(string name, string description, double amount, string date, string categoryName) : base(name, description, amount)
    {
        _categoryName = categoryName;
        _date = date;
        _isExpense = true;
    }
    public override string GetStringRepresentation()
    {
        return $"ExpenseTransaction|{_name}|{_description}|{_amount}|{_date}|{_categoryName}";
    }

    public string GetCategoryName()
    {
        return _categoryName;
    }
}