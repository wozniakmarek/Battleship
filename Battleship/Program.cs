    namespace Battleships;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Battleships!");
            Console.WriteLine("Press any key to start the game.");
            Console.ReadKey();
            Console.Clear();

            var game = new Game();
            game.Start();
        }
    }