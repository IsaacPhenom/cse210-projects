using System;

// To exceed the core requirements, I added a "Mood" property to the Entry class.
// When the user writes a new entry, the program asks for their current mood, 
// saves it in the entry, and writes it to the text file along with the rest of the data.

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        bool keepRunning = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (keepRunning)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGen.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();
                
                Console.WriteLine("What is your current mood?");
                Console.Write("> ");
                string mood = Console.ReadLine();

                Entry newEntry = new Entry();
                newEntry.Date = DateTime.Now.ToShortDateString();
                newEntry.PromptText = prompt;
                newEntry.EntryText = response;
                newEntry.Mood = mood;
                
                theJournal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                theJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();
                theJournal.LoadFromFile(fileName);
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();
                theJournal.SaveToFile(fileName);
            }
            else if (choice == "5")
            {
                keepRunning = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}