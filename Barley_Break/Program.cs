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
            //Caretaker caretaker = new Caretaker(gameBoard); // Useless
            gameBoard.PrintBoard();

            gameBoard.Attach(new MoveObserver());
            gameBoard.Notify();

            DefaulBoardController controller = new DefaulBoardController(gameBoard);
            //controller.SetBoard(gameBoard);

            Console.WriteLine("_______START_______");

            Console.WriteLine("-----");
            //caretaker.Backup();
            controller.Move(3, 2);
            gameBoard.PrintBoard();
            Console.WriteLine("-----");
            //caretaker.Backup();
            controller.Move(2, 2);
            gameBoard.PrintBoard();
            Console.WriteLine("-----");
            //caretaker.Backup();
            controller.Move(2, 1);
            gameBoard.PrintBoard();
            Console.WriteLine("-----");

            Console.WriteLine("======== HISTORY ========");
            controller.ShowBackups();
            Console.WriteLine("+++++++++ UNDO +++++++++++");

            controller.Undo();
            gameBoard.PrintBoard();
            Console.WriteLine("-----");
            controller.Undo();
            gameBoard.PrintBoard();
            Console.WriteLine("-----");
            controller.Undo();
            gameBoard.PrintBoard();
            Console.WriteLine("-----");
        }
    }
}