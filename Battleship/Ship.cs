namespace Battleships;

public class Ship
{
    public int[] battleship { get; set; }
    public int[] destroyer1 { get; set; }
    public int[] destroyer2 { get; set; }
    public bool[] battleshipSunk;
    public bool[] destroyer1Sunk;
    public bool[] destroyer2Sunk;

    private readonly Random rnd;
    private bool isHorizontal;

    public Ship()
    {
        battleship = new int[5];
        destroyer1 = new int[4];
        destroyer2 = new int[4];
        battleshipSunk = new bool[5] { false, false, false, false, false };
        destroyer1Sunk = new bool[4] { false, false, false, false };
        destroyer2Sunk = new bool[4] { false, false, false, false };
        rnd = new Random();
    }
    
    public bool IsSunk(bool[] shipSunk)
    {
        for (var i = 0; i < shipSunk.Length; i++)
            if (shipSunk[i] == false)
                return false;

        return true;
    }

    public void PlaceShips()
    {
        // Place battleship
        var row = rnd.Next(0, 7);
        var col = rnd.Next(0, 7);
        isHorizontal = rnd.Next(0, 2) == 0 ? true : false;

        while (IsOverlap(row, col, 5, isHorizontal) || IsOutOfBounds(row, col, 5, isHorizontal) || IsAdjacent(row, col, 5, isHorizontal))
        {
            row = rnd.Next(0, 7);
            col = rnd.Next(0, 7);
            isHorizontal = rnd.Next(0, 2) == 0 ? true : false;
        }

        for (var i = 0; i < 5; i++) battleship[i] = isHorizontal ? 10 * row + col + i : 10 * (row + i) + col;

        // Place destroyer1
        do
        {
            row = rnd.Next(0, 8);
            col = rnd.Next(0, 8);
            isHorizontal = rnd.Next(0, 2) == 0 ? true : false;
        } while (IsOverlap(row, col, 4, isHorizontal, battleship) || IsOutOfBounds(row, col, 4, isHorizontal) ||
                 IsAdjacent(row, col, 4, isHorizontal, battleship));

        for (var i = 0; i < 4; i++) destroyer1[i] = isHorizontal ? 10 * row + col + i : 10 * (row + i) + col;

        // Place destroyer2
        do
        {
            row = rnd.Next(0, 8);
            col = rnd.Next(0, 8);
            isHorizontal = rnd.Next(0, 2) == 0 ? true : false;
        } while (IsOverlap(row, col, 4, isHorizontal, battleship, destroyer1) ||
                 IsOutOfBounds(row, col, 4, isHorizontal) ||
                 IsAdjacent(row, col, 4, isHorizontal, battleship, destroyer1));

        for (var i = 0; i < 4; i++) destroyer2[i] = isHorizontal ? 10 * row + col + i : 10 * (row + i) + col;

        // initialize the boolean array for each ship
        battleshipSunk = new bool[5];
        destroyer1Sunk = new bool[4];
        destroyer2Sunk = new bool[4];
    }

    public bool IsOverlap(int row, int col, int size, bool isHorizontal, params int[][] ships)
    {
        if (isHorizontal)
        {
            for (var i = -1; i <= size; i++)
            for (var j = 0; j < ships.Length; j++)
            for (var k = 0; k < ships[j].Length; k++)
                if (row + i >= 0 && row + i < 10 && col + i >= 0 && col + i < 10)
                    if (ships[j][k] == 10 * (row + i) + col + i)
                        return true;
        }
        else
        {
            for (var i = -1; i <= size; i++)
            for (var j = 0; j < ships.Length; j++)
            for (var k = 0; k < ships[j].Length; k++)
                if (row + i >= 0 && row + i < 10 && col >= 0 && col < 10)
                    if (ships[j][k] == 10 * (row + i) + col)
                        return true;
        }

        return false;
    }

    private bool IsOutOfBounds(int row, int col, int size, bool isHorizontal)
    {
        if (isHorizontal)
        {
            if (col + size > 10)
                return true;
        }
        else
        {
            if (row + size > 10)
                return true;
        }

        return false;
    }

    public bool IsAdjacent(int row, int col, int size, bool isHorizontal, params int[][] ships)
    {
        if (isHorizontal)
        {
            for (var i = -1; i <= size; i++)
            for (var j = -1; j <= 1; j++)
            for (var k = 0; k < ships.Length; k++)
            for (var l = 0; l < ships[k].Length; l++)
                if (row + i >= 0 && row + i < 10 && col + j + i >= 0 && col + j + i < 10)
                    if (ships[k][l] == 10 * (row + i) + col + j + i)
                        return true;
        }
        else
        {
            for (var i = -1; i <= 1; i++)
            for (var j = -1; j <= size; j++)
            for (var k = 0; k < ships.Length; k++)
            for (var l = 0; l < ships[k].Length; l++)
                if (row + i + j >= 0 && row + i + j < 10 && col + i >= 0 && col + i < 10)
                    if (ships[k][l] == 10 * (row + i + j) + col + i)
                        return true;
        }

        return false;
    }


    public bool SetHit(int[] hitCoordinate)
    {
        for (var i = 0; i < battleship.Length; i++)
            if (hitCoordinate[0] == battleship[i] / 10 && hitCoordinate[1] == battleship[i] % 10)
            {
                battleshipSunk[i] = true;
                break;
            }

        for (var i = 0; i < destroyer1.Length; i++)
            if (hitCoordinate[0] == destroyer1[i] / 10 && hitCoordinate[1] == destroyer1[i] % 10)
            {
                destroyer1Sunk[i] = true;
                break;
            }

        for (var i = 0; i < destroyer2.Length; i++)
            if (hitCoordinate[0] == destroyer2[i] / 10 && hitCoordinate[1] == destroyer2[i] % 10)
            {
                destroyer2Sunk[i] = true;
                break;
            }

        return false;
    }
}