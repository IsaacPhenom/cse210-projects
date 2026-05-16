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

    // This will go through all entries and tells each one to display itself
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // This will save the complete journal list to a text file
    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                // We will use '|' as a separator so commas in user entries don't break things
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
        Console.WriteLine("Journal saved successfully!");
    }

    // This will load journal entries from a text file and replaces current memory entries
    public void LoadFromFile(string file)
    {
        // Clear out any current unsaved entries first
        _entries.Clear();

        if (File.Exists(file))
        {
            string[] lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {
                // We will split the text line back into its 3 original parts
                string[] parts = line.Split('|');

                if (parts.Length == 3)
                {
                    Entry loadedEntry = new Entry();
                    loadedEntry._date = parts;
                    loadedEntry._promptText = parts;
                    loadedEntry._entryText = parts;

                    _entries.Add(loadedEntry);
                }
            }
            Console.WriteLine("Journal loaded successfully!");
        }
        else
        {
            Console.WriteLine("Error: That file could not be found.");
        }
    }
}