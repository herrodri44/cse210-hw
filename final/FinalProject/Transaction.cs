public abstract class Transaction : FinancialEntity
{
    protected string _date;
    protected bool _isExpense;

    public Transaction(string name, string description, double amount)
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        _name = name;
        _description = description;
        _amount = amount;
        _date = dateText;
    }

    public abstract string GetStringRepresentation();
    public virtual string GetStringDetails()
    {   
        return $"{_name}: ${_amount} | ({_description}) - {_date}";
    }

    public string GetTransactionName()
    {
        return _name;
    }
    public double GetTransactionAmount()
    {
        return _amount;
    }

    public bool IsExpense()
    {
        return _isExpense;
    }
}