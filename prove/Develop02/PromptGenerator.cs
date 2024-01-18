using System;
using System.Collections.Generic;

public class PromptGenerator {

    public List<string> _promptsList = new List<string>()
    {
    "What was the most interesting thing that happened today?",
    "What activities or events had the most impact on your mood today?",
    "Can you describe a conversation or interaction that stood out to you?",
    "Is there something specific you're looking forward to or planning for tomorrow based on your experiences today?",
    "Did you learn something new or have any interesting discoveries?",
    "Was there a moment from your day that made you smile or laugh?",
    };

    public string ChooseRandom()
    {
        Random randomGenerator = new Random();
        int randomPosition = randomGenerator.Next(0, 5);
        return _promptsList[randomPosition];
    }
}