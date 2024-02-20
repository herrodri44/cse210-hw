public class IncomeTransaction : Transaction
{
    public IncomeTransaction(string name, string description, double amount) : base(name, description, amount)
    {
        _isExpense = false;
    }
    public IncomeTransaction(string name, string description, double amount, string date) : base(name, description, amount)
    {
        _isExpense = false;
        _date = date;
    }

    public override string GetStringRepresentation()
    {
        return $"IncomeTransaction|{_name}|{_description}|{_amount}|{_date}";
    }
}