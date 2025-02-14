class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.WriteLine("\n1. Add Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Save Progress");
            Console.WriteLine("5. Load Progress");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter goal name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter description: ");
                    string description = Console.ReadLine();
                    Console.Write("Enter point value: ");
                    int points = int.Parse(Console.ReadLine());

                    Console.WriteLine("Select goal type: 1) Simple 2) Eternal 3) Checklist");
                    int type = int.Parse(Console.ReadLine());

                    if (type == 1)
                        manager.AddGoal(new SimpleGoal(name, description, points));
                    else if (type == 2)
                        manager.AddGoal(new EternalGoal(name, description, points));
                    else if (type == 3)
                    {
                        Console.Write("Enter target count: ");
                        int targetCount = int.Parse(Console.ReadLine());
                        Console.Write("Enter bonus points: ");
                        int bonusPoints = int.Parse(Console.ReadLine());
                        manager.AddGoal(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
                    }
                    break;

                case "2":
                    manager.ShowGoals();
                    Console.Write("Enter goal number: ");
                    int goalIndex = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordEvent(goalIndex);
                    break;

                case "3":
                    manager.ShowGoals();
                    break;

                case "4":
                    manager.SaveProgress("progress.txt");
                    Console.WriteLine("Progress saved.");
                    break;

                case "5":
                    manager.LoadProgress("progress.txt");
                    Console.WriteLine("Progress loaded.");
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
