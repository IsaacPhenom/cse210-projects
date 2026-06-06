public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.") 
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < futureTime)
        {
            Console.Write("\nBreathe in...");
            ShowCountDown(4);
            Console.Write("\nNow breathe out...");
            ShowCountDown(6);
            Console.WriteLine();
        }
        
        DisplayEndingMessage();
    }
}