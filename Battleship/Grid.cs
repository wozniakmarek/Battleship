namespace Battleships;

public class Grid
{
    public char[,] grid = new char[10, 10];

    public void Initialize()
    {
        for (var i = 0; i < 10; i++)
        for (var j = 0; j < 10; j++)
            grid[i, j] = '.';
    }

    public void Draw()
    {
        Console.Write("  \n   ");

        for (var i = 0; i < 10; i++) Console.Write((char)('A' + i) + " ");
        Console.WriteLine();
        for (var i = 0; i < 10; i++)
        {
            if (i < 9)
                Console.Write(" " + (i + 1) + " ");
            else
                Console.Write(i + 1 + " ");
            for (var j = 0; j < 10; j++)
                if (grid[i, j] == 'S')
                {
                    Console.Write(". ");
                }
                else if (grid[i, j] == 'X')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("X ");
                    Console.ResetColor();
                }
                else if (grid[i, j] == 'O')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("O ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(grid[i, j] + " ");
                }

            Console.WriteLine();
        }
    }

    public void MarkShip(int row, int col)
    {
        grid[row, col] = 'S';
    }

    public void MarkHit(int[] coordinate)
    {
        var row = coordinate[0];
        var col = coordinate[1];
        grid[row, col] = 'X';
    }


    public void MarkMiss(int[] coordinate)
    {
        var row = coordinate[0];
        var col = coordinate[1];
        grid[row, col] = 'O';
    }

    public bool IsShip(int row, int col)
    {
        return grid[row, col] == 'S';
    }

    public bool IsHit(int[] coordinate, int[] shipCoordinates)
    {
        var position = 10 * coordinate[0] + coordinate[1];
        for (var i = 0; i < shipCoordinates.Length; i++)
            if (position == shipCoordinates[i])
                return true;
        return false;
    }

    public bool CheckCoordinates(int[] coordinate)
    {
        if (coordinate[0] < 0 || coordinate[0] >= grid.GetLength(0) || coordinate[1] < 0 || coordinate[1] >= grid.GetLength(1))
        {
            Console.WriteLine("Please enter valid coordinates.");
            return false;
        }

        if (grid[coordinate[0], coordinate[1]] == 'X' || grid[coordinate[0], coordinate[1]] == 'O')
        {
            Console.WriteLine("You have already entered these coordinates, please enter new ones.");
            return false;
        }

        return true;
    }
}