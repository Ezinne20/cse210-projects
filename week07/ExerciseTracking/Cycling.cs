public class Cycling : Activity
{
    public double SpeedInMph { get; set; }

    // Constructor
    public Cycling(string date, int duration, double speedInMph) : base(date, duration)
    {
        SpeedInMph = speedInMph;
    }

    // Implementing abstract methods
    public override double GetDistance()
    {
        return (SpeedInMph * Duration) / 60; // Distance = Speed * Time
    }

    public override double GetSpeed()
    {
        return SpeedInMph;
    }

    public override double GetPace()
    {
        return 60 / SpeedInMph; // Pace = 60 / Speed (minutes per mile)
    }
}
