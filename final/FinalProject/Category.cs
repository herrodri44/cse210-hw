public class Category : FinancialEntity
{
    public Category(string name, string description, double amount)
    {
        _name = name;
        _description = description;
        _amount = amount;
    }

    public string GetStringRepresentation()
    {
        return $"Category|{_name}|{_description}|{_amount}";
    }
    public string GetStringDetails()
    {
        return $"{_name}";
    }
     public string GetCategoryName()
    {
        return _name;
    }
}