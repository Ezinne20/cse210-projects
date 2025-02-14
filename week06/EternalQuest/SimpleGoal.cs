class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points) {}

    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Goal completed! You earned {_points} points.");
    }
}
