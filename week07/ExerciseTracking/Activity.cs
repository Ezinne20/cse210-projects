using System;

public abstract class Activity
{
    // Shared properties
    public string Date { get; set; }
    public int Duration { get; set; } // in minutes

    // Constructor
    public Activity(string date, int duration)
    {
        Date = date;
        Duration = duration;
    }

    // Abstract methods to be overridden in derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // GetSummary method to provide a summary of the activity
    public virtual string GetSummary()
    {
        return $"{Date} {this.GetType().Name} ({Duration} min) - Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}
