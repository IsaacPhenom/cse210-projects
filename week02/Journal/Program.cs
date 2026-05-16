using System;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        int choice = -1;

        // This will loop until the user chooses option 5 to Quit
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
                // We will get a random prompt and show it
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\n{prompt}");
                Console.Write("> ");
                string response = Console.ReadLine();

                // We will ask for a mood rating
                Console.Write("Rate your mood today (1-5): ");
                string mood = Console.ReadLine();

                // We will get the current date as a simple string
                string dateText = DateTime.Now.ToShortDateString();

                Entry newEntry = new Entry();
                newEntry._date = dateText;
                newEntry._promptText = prompt;
                newEntry._entryText = $"[Mood: {mood}/5] {response}";

                // We will hand the entry over to the journal
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
