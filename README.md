# BattleShipCS

Instructions:
1. Open the .sln project in the Visual Studio environment.
2. Set the battleships project as the startup project.
3. Start the project.

#Ship#

The Ship class is part of the Battleships namespace. It has three properties, battleship, destroyer1, and destroyer2, which are arrays of integers representing the location of each ship on the game board. It also has three properties, battleshipSunk, destroyer1Sunk, and destroyer2Sunk, which are arrays of booleans representing whether each section of each ship has been hit.

The class also has a private readonly Random object, rnd, and a private boolean, isHorizontal, which is used to randomly place the ships on the game board.

The Ship constructor initializes the ship arrays and sets all elements of the sunk arrays to false.

The IsSunk method takes in a shipSunk array and returns whether all elements of the array are true, indicating that the ship has been sunk.

The PlaceShips method randomly places the ships on the game board and makes sure that they do not overlap or go out of bounds. It also calls other methods, IsOverlap, IsOutOfBounds, and IsAdjacent to check for these conditions.

Finally, it initializes the sunk arrays for each ship.

#Grid#

The Grid class is part of the Battleships namespace. It has a 2D char array, grid, representing the game board.

The Initialize method sets all elements of the grid array to '.'.

The Draw method draws the grid on the console with the first row and first column displaying letters and numbers respectively as coordinates. It also displays 'X' in red color and 'O' in yellow color representing hit and miss respectively.

The MarkShip method marks a ship on the grid at the given row and column.

The MarkHit and MarkMiss methods mark a hit or miss on the grid at the given coordinates.

The IsShip method checks if there is a ship at the given row and column.

The IsHit method checks if a given coordinate is a hit on a ship by comparing it to the given ship coordinates.

The CheckCoordinates method checks if the given coordinates are valid and haven't been entered before, it returns false if the coordinates are not valid and displays a message on the console.

#Game#

The Game class is part of the Battleships namespace. It has two properties, grid and ship, which are objects of the Grid and Ship classes respectively.

The Game constructor initializes the grid and ship properties.

The Start method starts the game by initializing the grid and placing the ships, it then enters a loop where it waits for player input, converts the input to coordinates, checks if the coordinates are valid, checks if the coordinates are a hit or a miss, marks the grid accordingly, and checks if the ships are sunk. It also ends the game if all ships are sunk.

The IsGameOver method checks if all ships are sunk and if so, it displays a message and the final grid on the console.

The GetCoordinate method prompts the user for input and checks if the input is a valid coordinate.

The IsValidCoordinate method checks if the input is a valid coordinate.

The ConvertCoordinate method converts the input to coordinate.

The IsGameOver method checks if all ships are sunk and if so, it displays a message and the final grid on the console.
