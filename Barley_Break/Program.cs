using Barley_Break.src;

namespace Barley_Break
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            GameBoard board = new GameBoard();
            board.PrintBoard();
            string json = board.Clone();
            board.Save(json);
            Console.WriteLine(board.Parse());
        }
    }
}