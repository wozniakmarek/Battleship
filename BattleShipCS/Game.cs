namespace Battleships;

public class Game
{
    public Grid grid;
    public Ship ship;

    public Game()
    {
        grid = new Grid();
        ship = new Ship();
    }

    public void Start()
    {
        grid.Initialize();
        ship.PlaceShips();
        var shipsSunk = new bool[3] { false, false, false };

        while (true)
        {
            grid.Draw();
            var input = GetCoordinate();
            var coordinate = ConvertCoordinate(input);
            if (grid.CheckCoordinates(coordinate))
            {
                if (coordinate != null && grid.IsHit(coordinate, ship.battleship))
                {
                    grid.MarkHit(coordinate);
                    Console.WriteLine("HIT!");
                    ship.SetHit(coordinate);
                    if (ship.IsSunk(ship.battleshipSunk))
                    {
                        Console.WriteLine("You have sunk the battleship!");
                        shipsSunk[0] = true;
                    }
                }
                else if (coordinate != null && grid.IsHit(coordinate, ship.destroyer1))
                {
                    grid.MarkHit(coordinate);
                    Console.WriteLine("HIT!");
                    ship.SetHit(coordinate);
                    if (ship.IsSunk(ship.destroyer1Sunk))
                    {
                        Console.WriteLine("You have sunk the destroyer1!");
                        shipsSunk[1] = true;
                    }
                }
                else if (coordinate != null && grid.IsHit(coordinate, ship.destroyer2))
                {
                    grid.MarkHit(coordinate);
                    Console.WriteLine("HIT!");
                    ship.SetHit(coordinate);
                    if (ship.IsSunk(ship.destroyer2Sunk))
                    {
                        Console.WriteLine("You have sunk the destroyer2!");
                        shipsSunk[2] = true;
                    }
                }
                else if (coordinate != null)
                {
                    grid.MarkMiss(coordinate);
                    Console.WriteLine("MISS!");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                if (IsGameOver(shipsSunk)) break;
            }
        }
    }

    public bool IsGameOver(bool[] shipsSunk)
    {
        var gameOver = true;
        for (var i = 0; i < shipsSunk.Length; i++)
            if (!shipsSunk[i])
            {
                gameOver = false;
                break;
            }

        if (gameOver)
        {
            Console.WriteLine("Congratulations! You have sunk all ships!");
            grid.Draw();
            //Console.ReadKey();
        }

        return gameOver;
    }

    private string GetCoordinate()
    {
        Console.WriteLine("Enter a coordinate to target (e.g. A5): ");
        var input = Console.ReadLine();
        while (!IsValidCoordinate(input))
        {
            Console.WriteLine("Invalid Coordinate. Please enter a letter and a number.");
            input = Console.ReadLine();
        }

        return input;
    }

    public bool IsValidCoordinate(string input)
    {
        int row;
        int col;
        if (input.Length == 3 && char.IsUpper(input[0]) && char.IsDigit(input[1]) && char.IsDigit(input[2]))
        {
            col = input[0] - 'A';
            row = int.Parse(input.Substring(1)) - 1;
            if (col >= 0 && col <= 9 && row >= 0 && row <= 9) return true;
        }
        else if (input.Length == 2 && char.IsUpper(input[0]) && char.IsDigit(input[1]))
        {
            col = input[0] - 'A';
            row = int.Parse(input[1].ToString()) - 1;
            if (col >= 0 && col <= 9 && row >= 0 && row <= 9) return true;
        }
        else
        {
            return false;
        }

        return false;
    }

    private int[] ConvertCoordinate(string input)
    {
        var col = input[0] - 'A';
        var row = int.Parse(input.Substring(1)) - 1;
        return new[] { row, col };
    }
}