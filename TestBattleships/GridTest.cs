using System;
using Xunit;
using Xunit.Abstractions;
using Battleships;

namespace TestBattleships
{
    public class GridTest
    {
        private readonly ITestOutputHelper _output;
        public GridTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void TestDraw()
        {
            var grid = new Grid();
            grid.Draw();
            _output.WriteLine(grid.ToString());
            Assert.True(grid.ToString().Length > 0);
        }
        
        [Fact]
        public void TestInitialize()
        {
            var grid = new Grid();
            grid.Initialize();
            Assert.True(grid.ToString().Length > 0);
        }

        [Fact]
        public void TestMarkShip()
        {
            var grid = new Grid();
            grid.MarkShip(1, 1);
            Assert.Equal('S', grid.grid[1, 1]);
        }
        
        [Fact]
        public void TestCheckCoordinates()
        {
            // Arrange
            Grid grid = new Grid();
            int[] coordinate = new int[2];

            // Test out of grid
            coordinate[0] = -1;
            coordinate[1] = -1;
            Assert.False(grid.CheckCoordinates(coordinate));

            coordinate[0] = 11;
            coordinate[1] = 11;
            Assert.False(grid.CheckCoordinates(coordinate));

            // Test valid coordinates
            coordinate[0] = 5;
            coordinate[1] = 5;
            Assert.True(grid.CheckCoordinates(coordinate));

            coordinate[0] = 0;
            coordinate[1] = 0;
            Assert.True(grid.CheckCoordinates(coordinate));

            coordinate[0] = 9;
            coordinate[1] = 9;
            Assert.True(grid.CheckCoordinates(coordinate));
        }

        [Fact]
        public void TestMarkHit()
        {
            // Arrange
            var grid = new Grid();
            var ship = new Ship();
            ship.PlaceShips();
            grid.MarkShip(1, 1);

            // Act
            var validCoordinate = new int[] { 1, 1 };
            var invalidCoordinate = new int[] { -1, -1 };
            var outOfRangeCoordinate = new int[] { 11, 11 };

            // Assert
            Assert.True(grid.CheckCoordinates(validCoordinate));
            Assert.False(grid.CheckCoordinates(invalidCoordinate));
            Assert.False(grid.CheckCoordinates(outOfRangeCoordinate));
            grid.MarkHit(validCoordinate);
            Assert.Equal('X', grid.grid[1, 1]);
            Assert.False(grid.CheckCoordinates(validCoordinate));
        }

        [Fact]
        public void TestMarkMiss()
        {
            // Arrange
            var grid = new Grid();
            var ship = new Ship();
            ship.PlaceShips();
            grid.MarkShip(1, 1);

            // Act
            var validCoordinate = new int[] { 2, 2 };
            var invalidCoordinate = new int[] { -1, -1 };
            var outOfRangeCoordinate = new int[] { 11, 11 };

            // Assert
            Assert.True(grid.CheckCoordinates(validCoordinate));
            Assert.False(grid.CheckCoordinates(invalidCoordinate));
            Assert.False(grid.CheckCoordinates(outOfRangeCoordinate));
            grid.MarkMiss(validCoordinate);
            Assert.Equal('O', grid.grid[2, 2]);
            Assert.False(grid.CheckCoordinates(validCoordinate));
        }
    }
}