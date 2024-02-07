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

            gameBoard.Attach(new MoveObserver());
            gameBoard.Notify();

            DefaulBoardController controller = new DefaulBoardController();
            controller.SetBoard(gameBoard);

            Console.WriteLine("-----");
            controller.Move(3, 2);
            gameBoard.PrintBoard();
            Console.WriteLine("-----");
            controller.Move(2, 2);
            gameBoard.PrintBoard();
            Console.WriteLine("-----");
            controller.Move(1, 1);
            gameBoard.PrintBoard();
            Console.WriteLine("-----");
            Thread.Sleep(200);
        }
    }
}