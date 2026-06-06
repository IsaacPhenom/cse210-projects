using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("How long, in seconds, would you like for your session? ");
        
        //This is an error handling in case the user doesn't type a number
        if (!int.TryParse(Console.ReadLine(), out _duration))
        {
            _duration = 30; // Default to 30 seconds if input is invalid
        }
        
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < futureTime)
        {
            Console.Write(animationStrings[i]);
            Thread.Sleep(250);
            Console.Write("\b \b"); // Erase the character
            i++;
            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            
            // Handle double-digit countdown overwrites cleanly
            if (i >= 10) Console.Write("\b\b  \b\b");
            else Console.Write("\b \b");
        }
    }
}