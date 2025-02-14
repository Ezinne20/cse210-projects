abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public abstract void RecordEvent();

    public virtual string GetDetailsString()
    {
        return $"[{(_isComplete ? "X" : " ")}] {_name} - {_description}";
    }

    public int GetPoints() => _points;
}
