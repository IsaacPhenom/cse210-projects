using System;

public class Entry
{
    // Member variables
    public string _date;
    public string _promptText;
    public string _entryText;

    // This will display a single entry's contents
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}");
        Console.WriteLine(); 
    }
}