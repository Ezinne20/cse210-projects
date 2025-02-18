using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create different activities
        Activity running = new Running("03 Nov 2022", 30, 3.0); // 3 miles
        Activity cycling = new Cycling("03 Nov 2022", 30, 12.0); // 12 mph
        Activity swimming = new Swimming("03 Nov 2022", 30, 20); // 20 laps

        // Put activities in a list
        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        // Iterate through the list and print the summary for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
