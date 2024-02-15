public class IncomeTransaction : Transaction
{
    public IncomeTransaction(string name, string description, double amount) : base(name, description, amount)
    {
        _isExpense = false;
    }

    public override string GetStringRepresentation()
    {
        return $"IncomeTransaction|{_name}|{_amount}|{_description}|{_date}";
    }
}