// See https://aka.ms/new-console-template for more information
using System;

public delegate void SpinEventHandler(int energyLevel, int winningProbability);

public class Game
{
    public event SpinEventHandler SpinEvent;

    private int energyLevel = 1;
    private int winningProbability = 100;
    private int spinsLeft = 5;

    public void Spin()
    {
        if (spinsLeft > 0)
        {
            spinsLeft--;

            SpinEvent?.Invoke(energyLevel, winningProbability);

            Console.WriteLine($"Spin {6 - spinsLeft}: Energy Level: {energyLevel}, Winning Probability: {winningProbability}");

            // Update energy level and winning probability based on spin
            switch (spinsLeft)
            {
                case 4:
                    energyLevel += 1;
                    winningProbability += 10;
                    break;
                case 3:
                    energyLevel += 2;
                    winningProbability += 20;
                    break;
                case 2:
                    energyLevel += 3;
                    winningProbability += 30;
                    break;
                case 1:
                    energyLevel += 4;
                    winningProbability += 40;
                    break;
                case 0:
                    energyLevel += 5;
                    winningProbability += 50;
                    break;
            }
        }
    }

    public string DetermineResult()
    {
        if (energyLevel >= 4 && winningProbability > 60)
        {
            return "Winner";
        }
        else if (energyLevel >= 1 && winningProbability > 50)
        {
            return "Runner Up";
        }
        else
        {
            return "Looser";
        }
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter Your Name: ");
        string playerName = Console.ReadLine();

        Game game = new Game();

        // Subscribe to the SpinEvent
        game.SpinEvent += (energyLevel, winningProbability) =>
        {
            // Custom logic can be added here based on the event
        };

        for (int i = 0; i < 5; i++)
        {
            game.Spin();
        }

        string result = game.DetermineResult();
        Console.WriteLine($"Result: {result}");
    }
}
