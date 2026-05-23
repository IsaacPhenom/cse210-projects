using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                // We use ~|~ to separate the pieces of data safely
                outputFile.WriteLine($"{entry.Date}~|~{entry.PromptText}~|~{entry.EntryText}~|~{entry.Mood}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        // Clear the current journal before loading the new one
        _entries.Clear();

        string[] lines = File.ReadAllLines(file);
        
        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");
            
            // Make sure the line has all 4 parts before trying to read it
            if (parts.Length == 4)
            {
                Entry loadedEntry = new Entry
                {
                    Date = parts[0],
                    PromptText = parts[1],
                    EntryText = parts[2],
                    Mood = parts[3]
                };
                
                _entries.Add(loadedEntry);
            }
        }
    }
}