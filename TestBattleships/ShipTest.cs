using Battleships;

namespace TestBattleships;

public class ShipTest
{
    [Fact]
    public void TestIsSunk()
    {
        // Arrange
        var ship = new Ship();

        // Act
        ship.PlaceShips();
        for (var i = 0; i < ship.battleship.Length; i++)
            ship.battleshipSunk[i] = true;

        // Assert
        Assert.True(ship.IsSunk(ship.battleshipSunk));
    }

    [Fact]
    public void TestIsOverlap()
    {
        // Arrange
        var ship = new Ship();
        var battleship = new[] { 11, 12, 13, 14, 15 };
        var destroyer1 = new[] { 41, 31, 21, 11 };
        var destroyer2 = new[] { 61, 71, 81, 91 };


        // Act
        var result1 = ship.IsOverlap(1, 1, 5, true, battleship);
        var result2 = ship.IsOverlap(4, 2, 4, true, battleship, destroyer1);
        var result3 = ship.IsOverlap(6, 6, 4, true, battleship, destroyer1, destroyer2);

        // Assert
        Assert.True(result1);
        Assert.True(result2);
        Assert.False(result3);
    }


    [Fact]
    public void TestIsAdjacent()
    {
        // Arrange
        var ship = new Ship();
        var battleship = new[] { 24, 25, 26, 27, 28 };
        var destroyer1 = new[] { 52, 62, 72, 82 };

        // Act
        var result1 = ship.IsAdjacent(1, 1, 5, true);
        var result2 = ship.IsAdjacent(4, 3, 4, true, battleship);
        var result3 = ship.IsAdjacent(4, 5, 2, true, battleship, destroyer1);

        // Assert
        Assert.False(result1);
        Assert.False(result2);
        Assert.True(result3);
    }
    [Fact]
    public void TestSetHit()
    {
        // Arrange
        var ship = new Ship();
        ship.PlaceShips();
        ship.battleship = new int[] { 11, 12, 13, 14, 15 }; // set known positions for battleship
        ship.destroyer1 = new int[] { 21, 31, 41, 51 };
        ship.destroyer2 = new int[] { 22, 32, 42, 52 };
        int[] hitCoordinate = { 11, 12, 13, 14, 15, 21, 31, 41, 51, 62, 72, 82, 92 };

        // Act
        for (var i = 0; i < hitCoordinate.Length; i++)
        {
            ship.SetHit(new int[] { hitCoordinate[i] / 10, hitCoordinate[i] % 10 });
        }

        // Assert
        for (var i = 0; i < ship.battleshipSunk.Length; i++)
        {
            Assert.True(ship.battleshipSunk[i]);
        }
        for (var i = 0; i < ship.destroyer1Sunk.Length; i++)
        {
            Assert.True(ship.destroyer1Sunk[i]);
        }
        for (var i = 0; i < ship.destroyer2Sunk.Length; i++)
        {
            Assert.False(ship.destroyer2Sunk[i]);
        }
    }

}