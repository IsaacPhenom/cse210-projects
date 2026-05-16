using System;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int userNumber = -1;

        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        //  We will compute the sum (total) of the numbers
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number; 
        }

        //  We wil compute the average
        double average = (double)sum / numbers.Count;

        //  We will find the maximum (largest) number
        int max = numbers[0]; 
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        //  We will print out the results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}