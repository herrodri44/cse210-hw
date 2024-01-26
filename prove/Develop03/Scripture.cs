using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private Random _randomGenerator = new Random();
    private string _originalText; 

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _originalText = text;

        ConvertTextToList(text);
    }

    public Scripture(string reference, string text)
    {
        _originalText = text;
        _reference = ConvertStringToReferece(reference);
        ConvertTextToList(text);
    }

    private void ConvertTextToList(string text)
    {
        _words.Clear();
        
        List<string> scriptureWords = text.Split(' ').ToList();
        foreach(string wordText in scriptureWords)
        {
            Word newWord = new Word(wordText);
            _words.Add(newWord);
        }
    }

    private Reference ConvertStringToReferece(string text)
    {
        // John 13:34-35
        string [] split = text.Split(new Char[] { ' ', ':', '-' });
        string book = split[0];
        int chapter = int.Parse(split[1]);
        int verse = int.Parse(split[2]);
        int endVerse = split.Length == 3 ? 0 : int.Parse(split[3]);

        return new Reference(book, chapter, verse, endVerse);
    }
 
    public void RestartScripture()
    {
        ConvertTextToList(_originalText);
    }

    public void HideRandomWords(int wordsToHide)
    {
        bool allWordsHidden = false;
        for (int i = 0; i < wordsToHide; i++)
        {
            allWordsHidden = isCompletelyHidden();
            if (allWordsHidden)
            {
                break;
            }
            HideWord();
        }
    }

    private void HideWord()
    {
        int hideIndex;
        hideIndex = _randomGenerator.Next(0, _words.Count);
        bool isHidden = _words[hideIndex].isHidden();

        if (!isHidden) 
        {
            _words[hideIndex].Hide();
        } else 
        {
            HideWord();
        }
    }

    public string GetDisplayText()
    {   
        string text = _reference.GetDisplayText();
        foreach (Word wordText in _words)
        {
            text = $"{text} {wordText.GetDisplayText()}";
        }
        return text;
    }

    public bool isCompletelyHidden()
    {
        return _words.All( w => w.isHidden() == true);
    }
    
    public int GetAmountOfHiddenWords()
    {
        List<Word> hiddenWords = _words.Where(w => w.isHidden()).ToList();
        return hiddenWords.Count;
    }



}