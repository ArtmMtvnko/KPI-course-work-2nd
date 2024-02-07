using Barley_Break.src;

namespace Barley_Break
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //GameBoard board = new DefaultBoard();
            //board.PrintBoard();
            //board.Save();
            //Console.WriteLine(board.Parse());

            GameBoard gameBoard = new DefaultBoardFactory().CreateBoard();
            gameBoard.PrintBoard();
        }
    }
}