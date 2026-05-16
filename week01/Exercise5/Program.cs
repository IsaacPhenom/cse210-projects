using System;

class Program
{
    static void Main()
    {
        DisplayWelcome();

        // 2. We will call the function to get the user's name and save it in a variable
        string userName = PromptUserName();

        // 3. We will then call the function to get the user's number and save it in a variable
        int userNumber = PromptUserNumber();

        // 4. We will pass the user's number into the square function and save the result
        int squaredNumber = SquareNumber(userNumber);

        // 5. We will pass both the name and the squared number to the display function
        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}