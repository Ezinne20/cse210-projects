public class Swimming : Activity
{
    public int Laps { get; set; }

    // Constructor
    public Swimming(string date, int duration, int laps) : base(date, duration)
    {
        Laps = laps;
    }

    // Implementing abstract methods
    public override double GetDistance()
    {
        return (Laps * 50) / 1000.0; // 50 meters per lap, converted to kilometers
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Duration) * 60; // Speed = Distance / Time
    }

    public override double GetPace()
    {
        return Duration / GetDistance(); // Pace in minutes per kilometer
    }
}
