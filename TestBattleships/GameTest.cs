using Battleships;
using Xunit;

namespace TestBattleships
{
    public class GameTest
    {  
        [Fact]
        public void TestIsGameOver()
        {
            // Arrange
            var game = new Game();
            var shipsSunk = new bool[] { true, true, true, true, true };
            var shipsSunk2 = new bool[] { false, false, false, false, false };
            var shipsSunk3 = new bool[] { true, false, false, false, false };
            var shipsSunk4 = new bool[] { false, true, false, false, false };
            var shipsSunk5 = new bool[] { false, false, true, false, false };
            var shipsSunk6 = new bool[] { false, false, false, true, false };
            var shipsSunk7 = new bool[] { false, false, false, false, true };
            var shipsSunk8 = new bool[] { true, true, true, true, false };

            // Act
            var result = game.IsGameOver(shipsSunk);
            var result2 = game.IsGameOver(shipsSunk2);
            var result3 = game.IsGameOver(shipsSunk3);
            var result4 = game.IsGameOver(shipsSunk4);
            var result5 = game.IsGameOver(shipsSunk5);
            var result6 = game.IsGameOver(shipsSunk6);
            var result7 = game.IsGameOver(shipsSunk7);
            var result8 = game.IsGameOver(shipsSunk8);
            

            // Assert
            Assert.True(result);
            Assert.False(result2);
            Assert.False(result3);
            Assert.False(result4);
            Assert.False(result5);
            Assert.False(result6);
            Assert.False(result7);
            Assert.False(result8);
            
        }
        //create a test for the IsValidCoordinate 
        [Fact]
        public void TestIsValidCoordinate()
        {
            // Arrange

            //Correct coordinates
            var game = new Game();
            var coordinate1 = "A1";
            var coordinate2 = "J10";

            //Incorrect coordinates
            var coordinate3 = "A11";
            var coordinate4 = "K1";
            var coordinate5 = "A0";
            var coordinate6 = "0A";
            var coordinate7 = "A";
            var coordinate8 = "1";
            var coordinate9 = "AA";
            var coordinate10 = "11";
            var coordinate11 = "A1A";
            var coordinate12 = "1A1";
            var coordinate13 = "A1A1";
            var coordinate14 = "A1A1A";
            var coordinate15 = "A1A1A1";

            // Act
            var result = game.IsValidCoordinate(coordinate1);
            var result2 = game.IsValidCoordinate(coordinate2);
            
            var result3 = game.IsValidCoordinate(coordinate3);
            var result4 = game.IsValidCoordinate(coordinate4);
            var result5 = game.IsValidCoordinate(coordinate5);
            var result6 = game.IsValidCoordinate(coordinate6);
            var result7 = game.IsValidCoordinate(coordinate7);
            var result8 = game.IsValidCoordinate(coordinate8);
            var result9 = game.IsValidCoordinate(coordinate9);
            var result10 = game.IsValidCoordinate(coordinate10);
            var result11 = game.IsValidCoordinate(coordinate11);
            var result12 = game.IsValidCoordinate(coordinate12);
            var result13 = game.IsValidCoordinate(coordinate13);
            var result14 = game.IsValidCoordinate(coordinate14);
            var result15 = game.IsValidCoordinate(coordinate15);

            // Assert
            Assert.True(result);
            Assert.True(result2);
            
            Assert.False(result3);
            Assert.False(result4);
            Assert.False(result5);
            Assert.False(result6);
            Assert.False(result7);
            Assert.False(result8);
            Assert.False(result9);
            Assert.False(result10);
            Assert.False(result11);
            Assert.False(result12);
            Assert.False(result13);
            Assert.False(result14);
            Assert.False(result15);
            

        }
    }
}
