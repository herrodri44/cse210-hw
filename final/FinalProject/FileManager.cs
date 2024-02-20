public class FileManager
{
    public void SaveToFile(Budget budget)
    {
        Console.WriteLine("");
        Console.Write("What is the filename for the budget file? ");
        string fileName = Console.ReadLine();
        List<string> lists = budget.GetStringRepresentations();
        double income = budget.GetIncome();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine($"Income|{income}");
            foreach (string item in lists)
            {
                outputFile.WriteLine(item);
            }
        }
    }
    public Budget LoadFromFile()
    {
        Console.WriteLine("");
        Console.Write("What is the filename for the budget file? ");
        string fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(fileName);
        int idx = 1;
        Budget newBudget = new Budget();
        Transaction transaction;
        double categoryAmount;
        
        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            switch (parts[0])
            {
                case "Income":
                    double income = double.Parse(parts[1]);
                    newBudget.SetIncome(income);
                    break;
                case "Category":
                    //  $"Category|{_name}|{_description}|{_amount}"
                    categoryAmount = double.Parse(parts[3]);
                    newBudget.AddCategory(parts[1], parts[2], categoryAmount);
                    break;
                case "IncomeTransaction":
                    categoryAmount = double.Parse(parts[3]);
                    transaction = new IncomeTransaction(parts[1], parts[2], categoryAmount, parts[4]);
                    newBudget.AddTransaction(transaction);
                    break;
                case "ExpenseTransaction":
                    //  $"ExpenseTransaction|{_name}|{_amount}|{_description}|{_date}|{_categoryName}"
                    categoryAmount = double.Parse(parts[3]);
                    transaction = new ExpenseTransaction(parts[1], parts[2], categoryAmount, parts[4], parts[5]);
                    newBudget.AddTransaction(transaction);
                    break;
                default:
                    Console.WriteLine($"Unable to read line {idx}");
                    break;
            }
            idx++;
        }

        return newBudget;
    }
    
}