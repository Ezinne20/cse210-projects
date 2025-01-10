using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine()); // Get the user's input and convert it to an integer

        string letter = ""; // Variable to hold the letter grade
        string sign = "";   // Variable to hold the sign (+ or -)

        // Determine the letter grade
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign
        if (grade >= 60 && grade < 90) // Exclude 'A' and 'F'
        {
            int lastDigit = grade % 10;

            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Handle special cases
        if (letter == "A" && sign == "+")
        {
            sign = ""; // No A+
        }
        else if (letter == "F")
        {
            sign = ""; // No F+ or F-
        }

        // Display the letter grade
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // Congratulate or encourage the user
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed the class!");
        }
        else
        {
            Console.WriteLine("Keep working hard, you'll get it next time!");
        }
    }
}
