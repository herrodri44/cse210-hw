using System;
using System.IO;
using System.Text.Json;

public class JsonLoader
{
    private string _filePath;

    public JsonLoader(string filePath)
    {
        _filePath = filePath;
    }

    public ScriptureContent[] LoadScriptures()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                Console.WriteLine($"Error: File not found at {_filePath}");
                return null;
            }
            string jsonString = File.ReadAllText(_filePath);
            ScriptureContent[] scriptureContent = JsonSerializer.Deserialize<ScriptureContent[]>(jsonString);

            return scriptureContent;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data from JSON file: {ex.Message}");
            return null;
        }
    }

    public List<Scripture> GetScriptureList()
    {
        ScriptureContent[] scripturesArray = LoadScriptures();
        List<Scripture> scriptureList = new List<Scripture>();

        foreach (ScriptureContent scripture in scripturesArray) 
        {
            Console.WriteLine(scripture._reference);
            Scripture newScripture = new Scripture(scripture._reference, scripture._text);
            scriptureList.Add(newScripture);
        }
        return scriptureList;
    }
}

public class ScriptureContent
{
    public string _reference { get; set; }
    public string _text { get; set; }
    public ScriptureContent(string reference, string text)
    {
        _reference = reference;
        _text = text;
    }
    public ScriptureContent()
    {
    }
}
