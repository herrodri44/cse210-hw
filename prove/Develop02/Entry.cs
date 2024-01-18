using System;

public class Entry{

    public string _prompt;

    public string _answer;

    public string _date;


    public void Display()
    {
        Console.WriteLine($"{_prompt} ({_answer}) {_date}");
    }
}