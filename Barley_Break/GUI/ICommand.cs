using Barley_Break.src;

namespace Barley_Break.GUI
{
    internal interface ICommand
    {
        public string Name { get; set; }
        void Execute();
    }

    class NewGameCommand : ICommand
    {
        public string Name { get; set; } = "New Game";

        public void Execute()
        {
            GameBoard gameBoard = new BoardFactory().CreateBoard();
            gameBoard.Attach(new MoveObserver());
            DefaulBoardController controller = new DefaulBoardController(gameBoard);

            while (!gameBoard.IsGameEnded())
            {
                try
                {
                    Console.Clear();
                    gameBoard.PrintBoard();

                    Console.WriteLine();

                    string moveInput = Console.ReadLine().Trim();

                    if (moveInput == "") continue;
                    if (moveInput == "q") break;
                    if (moveInput == "z")
                    {
                        controller.Undo();
                        continue;
                    }

                    string[] coordinates = moveInput.Split(' ');
                    int x = int.Parse(coordinates[0]);
                    int y = int.Parse(coordinates[1]);
                    controller.Move(x, y);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(3000);
                    continue;
                }
                
            }

            Console.Clear();
            gameBoard.PrintBoard();
            Console.WriteLine("\nYou won!!!");
            Thread.Sleep(3000);
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }
    }

    class ContinueGameCommand : ICommand
    {
        public string Name { get; set; } = "Continue";

        public void Execute()
        {
            GameBoard gameBoard = new SavedBoardFactory().CreateBoard();
            gameBoard.Attach(new MoveObserver());
            DefaulBoardController controller = new DefaulBoardController(gameBoard);

            while (!gameBoard.IsGameEnded())
            {
                try
                {
                    Console.Clear();
                    gameBoard.PrintBoard();

                    Console.WriteLine();

                    string moveInput = Console.ReadLine().Trim();

                    if (moveInput == "") continue;
                    if (moveInput == "q") break;
                    if (moveInput == "z")
                    {
                        controller.Undo();
                        continue;
                    }

                    string[] coordinates = moveInput.Split(' ');
                    int x = int.Parse(coordinates[0]);
                    int y = int.Parse(coordinates[1]);
                    controller.Move(x, y);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(3000);
                    continue;
                }

            }

            Console.Clear();
            gameBoard.PrintBoard();
            Console.WriteLine("\nYou won!!!");
            Thread.Sleep(3000);
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }
    }

    class RulesCommand : ICommand
    {
        public string Name { get; set; } = "Rules";

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Wellcome to the Barley Break!\n\n" +
                "Take couple of simple rules next:\n" +
                "\t1. To move square you must write its coordinate in console field.\n" +
                "\tCoordinates starts from 0. If you want to move square write down its coordinates as follow:\n\n" +
                "\tx y\n\n" +
                "\tFor example, you have next board:\n\n" +
                "\t 1  5 12  4\n" +
                "\t13  2 15  0\n" +
                "\t 3 11 10  6\n" +
                "\t 8  7  9 14\n\n" +
                "\tTo move \'15\' write \'2 1\' in field (without \'\')\n\n" +
                "\t2. To Exit enter \'q\' in the field (without \'\')\n\n" +
                "\t3. To Undo move - enter \'z\' in the field (without \'\')\n\n\n");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
