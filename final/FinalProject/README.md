# Open Ended Project - Budget Manager

For my final project I decided to create a budget manager using C# and the concepts of object oriented programming learned in this class.
In this program, the user will be able to plan and create a Budget dividing the expenses in Categories, recording expenses and incomes during the month and the ability to see the balance at any time to keep track of their persona finances. 
There is also a functionality to Save and Load the information in a file.

## Classes

* Budget
* BudgetManager
* Category
* ExpenseTransaction
* IncomeTransaction
* Transaction
* FinancialEntity
* FileManager

## Usage

Once you run the program, you will see a menu to interact with. The main idea is to create a Budget (first option) and during the creation, add different Categories providing the name, descriptions and amounts.
Once the Budget is created, the user can start adding Transactions. When a Transaction is created the first question is to indicate if it is an expense.  You can indicate so by typing 'y', and then adding the prompted information. 
After adding some Transactions you can see the current balance option to check how much you spent and how much of the budget is left.
You can also check the details of your transactions by category. 

## License

[MIT](https://choosealicense.com/licenses/mit/)