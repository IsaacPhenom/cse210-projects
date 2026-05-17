using System;
using System.Collections.Generic;
using System.IO; // Required for reading and writing files

// ============================================================================
// 1. THE MAIN PROGRAM CLASS (Controls the Menu and Game Flow)
// ============================================================================
class Program
{
    static void Main(string[] args)
    {
        // CREATE OBJECTS: This sets up our journal system and prompt tool
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        int choice = -1;

        // Loop until the user chooses option 5 to Quit
        while (choice != 5)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            string input = Console.ReadLine();
            choice = int.Parse(input);

            if (choice == 1)
            {
                // Step A: Get a random prompt and show it
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\n{prompt}");
                Console.Write("> ");
                string response = Console.ReadLine();

                // Creative Element: Let's track their mood too!
                Console.Write("Rate your mood today (1-5): ");
                string mood = Console.ReadLine();

                // Step B: Get the current date automatically as a string
                string dateText = DateTime.Now.ToShortDateString();

                // Step C: Package everything neatly into a new Entry object
                Entry newEntry = new Entry();
                newEntry._date = dateText;
                newEntry._promptText = prompt;
                newEntry._entryText = $"[Mood: {mood}/5] {response}";

                // Step D: Hand the entry over to the journal object to save in memory
                theJournal.AddEntry(newEntry);
            }
            else if (choice == 2)
            {
                Console.WriteLine("\n--- Journal Entries ---");
                theJournal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                theJournal.LoadFromFile(filename);
            }
            else if (choice == 4)
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                theJournal.SaveToFile(filename);
            }
        }

        Console.WriteLine("Goodbye!");
    }
}

// ============================================================================
// 2. THE ENTRY CLASS (The blueprint for a single journal page)
// ============================================================================
public class Entry
{
    // Variables to hold data for one entry
    public string _date;
    public string _promptText;
    public string _entryText;

    // Method to display this single entry to the screen
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}");
        Console.WriteLine(); // Blank line for clean formatting
    }
}

// ============================================================================
// 3. THE PROMPT GENERATOR CLASS (The brain that picks a question)
// ============================================================================
public class PromptGenerator
{
    public List<string> _prompts = new List<string>();

    // This constructor loads the questions automatically when the program starts
    public PromptGenerator()
    {
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
    }

    // Method to grab one question at random
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}

// ============================================================================
// 4. THE JOURNAL CLASS (The binder that holds all the entries together)
// ============================================================================
public class Journal
{
    // A master list to hold multiple Entry objects
    public List<Entry> _entries = new List<Entry>();

    // Adds an entry to the list
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Loops through the list and displays everything
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display(); // Calls the display method inside the Entry class
        }
    }

    // Saves the list data to a text file using a '|' character as a divider
    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
        Console.WriteLine("Journal saved successfully!");
    }

    // Reads a text file, builds brand new Entry objects, and updates our list
    public void LoadFromFile(string file)
    {
        _entries.Clear(); // Empties any unsaved entries currently in memory

        if (File.Exists(file))
        {
            string[] lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {
                // Split the line back into 3 parts using the '|' character
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