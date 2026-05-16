using System;
using System.Collections.Generic;

public class PromptGenerator
{
    // This is a list to hold our prompt strings
    public List<string> _prompts = new List<string>();

    // This will run automatically when we create a new PromptGenerator
    public PromptGenerator()
    {
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
    }

    // This will return a random prompt from the list
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count); // Picks a random index number
        return _prompts[index];
    }
}