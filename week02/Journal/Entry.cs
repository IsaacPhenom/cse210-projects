using System;

public class Entry
{
    // These hold the data for a single entry
    public string Date { get; set; }
    public string PromptText { get; set; }
    public string EntryText { get; set; }
    public string Mood { get; set; } // Added to exceed requirements

    // This method prints the entry to the screen
    public void Display()
    {
        Console.WriteLine($"Date: {Date} - Prompt: {PromptText}");
        Console.WriteLine($"Mood: {Mood}");
        Console.WriteLine(EntryText);
        Console.WriteLine(); // Adds a blank line for readability
    }
}