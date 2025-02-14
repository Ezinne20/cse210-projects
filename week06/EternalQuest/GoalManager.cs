class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];
            goal.RecordEvent();
            _score += goal.GetPoints();
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public void ShowGoals()
    {
        Console.WriteLine("Your Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine($"Current Score: {_score}");
    }

    public void SaveProgress(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine($"{goal.GetType().Name}|{goal.GetDetailsString()}");
            }
        }
    }

    public void LoadProgress(string filename)
    {
        if (File.Exists(filename))
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                _score = int.Parse(reader.ReadLine());
                _goals.Clear();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length > 1)
                    {
                        string type = parts[0];
                        string details = parts[1];

                        if (type == "SimpleGoal")
                        {
                            _goals.Add(new SimpleGoal(details, "", 100)); // Simplified for demo
                        }
                        else if (type == "EternalGoal")
                        {
                            _goals.Add(new EternalGoal(details, "", 50));
                        }
                        else if (type == "ChecklistGoal")
                        {
                            _goals.Add(new ChecklistGoal(details, "", 50, 10, 500));
                        }
                    }
                }
            }
        }
    }
}
