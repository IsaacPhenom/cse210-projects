using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. The program code ensures that the random number generator only selects words 
        //    that are not already hidden (logic found in Scripture.HideRandomWords).
        //    This also prevents the program from wasting time trying to hide already hidden words.
        
        // We will create the reference and scripture text
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        
        // We will pass them into the Scripture class
        Scripture scripture = new Scripture(reference, text);

        string userInput = "";

        // The main program loop
        while (userInput != "quit")
        {
            Console.Clear();

            // We will print the current state of the scripture
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine(); // Blank line for spacing

            // If the scripture is fully hidden, end the program automatically
            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            // Prompt the user
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            userInput = Console.ReadLine();

            if (userInput != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }
    }
}