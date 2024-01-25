using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private Random randomGenerator = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        List<string> scriptureWords = text.Split(' ').ToList();
        foreach(string wordText in scriptureWords)
        {
            Word newWord = new Word(wordText);
            _words.Add(newWord);
        }
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
        hideIndex = randomGenerator.Next(0, _words.Count);
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
    
    public int GetAmountOfWords()
    {
        return _words.Count;
    }

}