public static class Game {
    public static Player[] Players { get; set; } = new Player[2];
    public static int RoundCount { get; set; } = 0;
    public static int DrawCount { get; set; } = 0;

    public static void Main() {
        Players[0] = new Player("Player 1");
        Players[1] = new Player("Player 2");

        while (true) {
            Round round = new();
            RoundCount++;
        }
    }
}

public class Round {
    public bool IsComplete { get; set; } = false;

    public Round() {
        while (!IsComplete) {
            Console.Clear();
            Console.WriteLine($"Round: {Game.RoundCount} | Player 1 Score: {Game.Players[0].WinCount} | Player 2 Score: {Game.Players[1].WinCount} | Draws: {Game.DrawCount}");
            Console.WriteLine("-----------------------------------------------------------");

            foreach (Player player in Game.Players) {
                player.Choice = GetChoice(player);
            }

            GetWinner();
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
    }

    public Choice GetChoice(Player currentPlayer) {
        while (true) {
            Console.Write($"{currentPlayer.Name}, enter your choice: (1) Rock, (2) Paper, (3) Scissors: ");
            string input = Console.ReadLine()!;

            switch (input) {
                case "1":
                    return Choice.Rock;
                case "2":
                    return Choice.Paper;
                case "3":
                    return Choice.Scissors;
                default:
                    continue;
            }
        }
    }

    public void GetWinner() {
        if (Game.Players[0].Choice == Game.Players[1].Choice) {
            Game.DrawCount++;
            Console.WriteLine("It's a draw!");
            return;
        }

        if (Game.Players[0].Choice == Choice.Rock && Game.Players[1].Choice == Choice.Scissors) {
            Game.Players[0].WinCount++;
            Console.WriteLine($"{Game.Players[0].Name} wins!");
            return;
        }

        if (Game.Players[0].Choice == Choice.Paper && Game.Players[1].Choice == Choice.Rock) {
            Game.Players[0].WinCount++;
            Console.WriteLine($"{Game.Players[0].Name} wins!");
            return;
        }

        if (Game.Players[0].Choice == Choice.Scissors && Game.Players[1].Choice == Choice.Paper) {
            Game.Players[0].WinCount++;
            Console.WriteLine($"{Game.Players[0].Name} wins!");
            return;
        }

        Game.Players[1].WinCount++;
        Console.WriteLine($"{Game.Players[0].Name} wins!");
    }
}

public class Player {
    public string Name { get; set; }
    public Choice Choice { get; set; }
    public int WinCount { get; set; }

    public Player(string name) {
        Name = name;
    }
}

// Enumerations -----------------------/
public enum Choice { Rock, Paper, Scissors }