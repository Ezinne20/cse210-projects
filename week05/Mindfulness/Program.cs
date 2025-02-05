using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class ActivityTracker
{
    static void Main()
    {
        List<ActivityTask> activities = new List<ActivityTask>
        {
            new BreathingTask(),
            new ReflectionTask(),
            new ListingTask()
        };

        bool isActive = true;

        while (isActive)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Activity Program!");
            Console.WriteLine("Choose an activity to start:");
            Console.WriteLine("1. Breathing Task");
            Console.WriteLine("2. Reflection Task");
            Console.WriteLine("3. Listing Task");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    activities[0].Execute();
                    break;
                case "2":
                    activities[1].Execute();
                    break;
                case "3":
                    activities[2].Execute();
                    break;
                case "4":
                    DisplayActivityLog();
                    break;
                case "5":
                    isActive = false;
                    break;
                default:
                    Console.WriteLine("Please choose a valid option.");
                    break;
            }
        }
    }

    private static void DisplayActivityLog()
    {
        string logFilePath = "activity_log.txt";
        if (File.Exists(logFilePath))
        {
            Console.Clear();
            Console.WriteLine("Activity Log:");
            string[] logs = File.ReadAllLines(logFilePath);
            foreach (var log in logs)
            {
                Console.WriteLine(log);
            }
            PauseForSeconds(5);
        }
        else
        {
            Console.WriteLine("No activity logs found.");
            PauseForSeconds(3);
        }
    }

    private static void PauseForSeconds(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.WriteLine($"[{new string('.', i)}]");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}

// Base task class
public abstract class ActivityTask
{
    public string TaskName { get; set; }
    public string TaskDescription { get; set; }
    public int TaskDuration { get; set; }

    public ActivityTask(string name, string description)
    {
        TaskName = name;
        TaskDescription = description;
    }

    public void Execute()
    {
        DisplayStartMessage();
        PauseForSeconds(3);
        PerformTask();
        DisplayEndMessage();
        LogActivity();
    }

    protected virtual void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"{TaskName}: {TaskDescription}");
        Console.Write("Enter task duration in seconds: ");
        TaskDuration = int.Parse(Console.ReadLine() ?? "30");
        Console.WriteLine("Prepare to begin...");
    }

    protected abstract void PerformTask();

    protected virtual void DisplayEndMessage()
    {
        Console.WriteLine("Well done! You've finished the task.");
        Console.WriteLine($"You spent {TaskDuration} seconds on this task.");
        PauseForSeconds(3);
    }

    protected void LogActivity()
    {
        string logMessage = $"{DateTime.Now}: Completed {TaskName} for {TaskDuration} seconds.";
        File.AppendAllText("activity_log.txt", logMessage + Environment.NewLine);
    }

    protected void PauseForSeconds(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.WriteLine($"[{new string('.', i)}]");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}

// Breathing Task class
public class BreathingTask : ActivityTask
{
    public BreathingTask() : base("Breathing Task", "This task will guide you through a slow breathing exercise to help you relax and focus.")
    {
    }

    protected override void PerformTask()
    {
        int elapsed = 0;
        while (elapsed < TaskDuration)
        {
            Console.Clear();
            Console.WriteLine("Breathe in...");
            PauseForSeconds(4);
            Console.Clear();
            Console.WriteLine("Breathe out...");
            PauseForSeconds(4);
            elapsed += 8;
        }
    }
}

// Reflection Task class
public class ReflectionTask : ActivityTask
{
    private static List<string> reflectionPrompts = new List<string>
    {
        "Recall a time when you supported someone.",
        "Think about a challenging situation you overcame.",
        "Remember a time when you helped someone.",
        "Reflect on an act of kindness you performed."
    };

    private static List<string> reflectionQuestions = new List<string>
    {
        "Why was this moment significant for you?",
        "What did you learn from this experience?",
        "How did it make you feel?",
        "What did this teach you about yourself?"
    };

    public ReflectionTask() : base("Reflection Task", "This task helps you reflect on your strengths and past experiences of resilience.")
    {
    }

    protected override void PerformTask()
    {
        Random randomizer = new Random();
        int elapsed = 0;
        string selectedPrompt = reflectionPrompts[randomizer.Next(reflectionPrompts.Count)];
        Console.Clear();
        Console.WriteLine($"Prompt: {selectedPrompt}");
        PauseForSeconds(3);

        while (elapsed < TaskDuration)
        {
            string selectedQuestion = reflectionQuestions[randomizer.Next(reflectionQuestions.Count)];
            Console.Clear();
            Console.WriteLine(selectedQuestion);
            PauseForSeconds(5);
            elapsed += 5;
        }
    }
}

// Listing Task class
public class ListingTask : ActivityTask
{
    private static List<string> listingPrompts = new List<string>
    {
        "Who do you appreciate in your life?",
        "What are your personal strengths?",
        "Who have you helped recently?",
        "When have you felt a sense of peace this week?",
        "Who do you admire the most?"
    };

    public ListingTask() : base("Listing Task", "This task encourages you to think about the positive aspects of your life by listing things.")
    {
    }

    protected override void PerformTask()
    {
        Random randomizer = new Random();
        string selectedPrompt = listingPrompts[randomizer.Next(listingPrompts.Count)];
        Console.Clear();
        Console.WriteLine($"Prompt: {selectedPrompt}");
        PauseForSeconds(3);

        List<string> listedItems = new List<string>();
        int elapsed = 0;
        Console.WriteLine("Start listing your responses:");

        while (elapsed < TaskDuration)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                listedItems.Add(input);
            }
            elapsed++;
        }

        Console.Clear();
        Console.WriteLine($"You listed {listedItems.Count} items.");
        PauseForSeconds(3);
    }
}
