using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    public List<Entry> _entries = new List<Entry>();


    public void AddEntry(string prompt, string answer)
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        Entry newEntry = new Entry();
        newEntry._prompt = prompt;
        newEntry._answer = answer;
        newEntry._date = dateText;
        _entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        // Quick validation to let the user know if there is nothing to display
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display");
            return;
        }
        foreach(Entry entry in _entries)
        {
            Console.WriteLine($"Date: {entry._date} - Prompt: {entry._prompt}");
            Console.WriteLine(entry._answer);
            Console.WriteLine("");
        }
    }

    public void SaveFile(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach(Entry entry in _entries) 
            {
                outputFile.WriteLine($"{entry._prompt}||{entry._answer}||{entry._date}");
            }
        }
    }

    public void LoadFile(string fileName)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split("||");

            Entry fileEntry = new Entry();
            fileEntry._prompt = parts[0];
            fileEntry._answer = parts[1];
            fileEntry._date = parts[2];
            
            _entries.Add(fileEntry);
        }

    }
}