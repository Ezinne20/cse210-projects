class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        _currentCount++;
        if (_currentCount >= _targetCount)
        {
            _isComplete = true;
            Console.WriteLine($"Goal completed! You earned {_points + _bonusPoints} points.");
        }
        else
        {
            Console.WriteLine($"Good job! You earned {_points} points.");
        }
    }

    public override string GetDetailsString()
    {
        return $"[{(_isComplete ? "X" : " ")}] {_name} - {_description} (Completed {_currentCount}/{_targetCount})";
    }
}
