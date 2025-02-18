public class Running : Activity
{
    public double DistanceInMiles { get; set; }

    // Constructor
    public Running(string date, int duration, double distanceInMiles) : base(date, duration)
    {
        DistanceInMiles = distanceInMiles;
    }

    // Implementing abstract methods
    public override double GetDistance()
    {
        return DistanceInMiles;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Duration) * 60; // Speed in miles per hour
    }

    public override double GetPace()
    {
        return Duration / GetDistance(); // Pace in minutes per mile
    }
}
