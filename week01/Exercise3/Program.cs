using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain;

        do
        {
            Random random = new Random();
            int magicNumber = random.Next(1, 101);
            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("I'm thinking of a number between 1 and 100...");

            while (guess != magicNumber)
            {
                Console.WriteLine("What is your guess?");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} guesses!");
                }
            }

            Console.WriteLine("Do you want to play again? (yes/no)");
            playAgain = Console.ReadLine().ToLower();

        } while (playAgain == "yes");

        Console.WriteLine("Thanks for playing!");
    }
}
