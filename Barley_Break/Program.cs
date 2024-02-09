using Barley_Break.GUI;
using Barley_Break.src;

namespace Barley_Break
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GameBoard gameBoard = new SavedBoardFactory().CreateBoard();
            //gameBoard.PrintBoard();

            //gameBoard.Attach(new MoveObserver());
            //gameBoard.Notify();

            //DefaulBoardController controller = new DefaulBoardController(gameBoard);

            //Console.WriteLine("_______START_______");

            //Console.WriteLine("-----");
            //controller.Move(3, 2);
            //gameBoard.PrintBoard();
            //Console.WriteLine("-----");
            //controller.Move(2, 2);
            //gameBoard.PrintBoard();
            //Console.WriteLine("-----");
            //controller.Move(2, 1);
            //gameBoard.PrintBoard();
            //Console.WriteLine("-----");

            //Console.WriteLine("======== HISTORY ========");
            //controller.ShowBackups();
            //Console.WriteLine("+++++++++ UNDO +++++++++++");

            //controller.Undo();
            //gameBoard.PrintBoard();
            //Console.WriteLine("-----");
            //controller.Undo();
            //gameBoard.PrintBoard();
            //Console.WriteLine("-----");
            //controller.Undo();
            //gameBoard.PrintBoard();
            //Console.WriteLine("-----");

            // =========================================

            User user = new User();
            user.Builder = new StartMenuBuilder();
            user.BuildMenu();

            user.Run();
        }
    }
}