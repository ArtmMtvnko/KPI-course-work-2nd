using Barley_Break.src;

namespace Barley_Break.GUI
{
    internal interface ICommand
    {
        public string Name { get; set; }
        void Execute();
    }

    class MockCommand : ICommand
    {
        public string Name { get; set; } = "Mock";
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }

    class NewGameCommand : ICommand
    {
        public string Name { get; set; } = "New Game";

        public void Execute()
        {
            GameBoard gameBoard = new BoardFactory().CreateBoard();
            gameBoard.Attach(new MoveObserver());
            DefaulBoardController controller = new DefaulBoardController(gameBoard);

            // TODO: instead of true below make gameBoard.IsGameEnd() function
            while (true)
            {
                Console.Clear();
                gameBoard.PrintBoard();

                string moveInput = Console.ReadLine().Trim();

                if (moveInput == "") continue;

                string[] coordinates = moveInput.Split(' ');
                int x = int.Parse(coordinates[0]);
                int y = int.Parse(coordinates[1]);
                controller.Move(x, y);
                
            }

            while (Console.ReadLine().Trim() != "q") { }

            // TODO: Add undo on 'z'
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

            while (Console.ReadLine().Trim() != "q") { }
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
                "\tTo move \'15\' wtire \'2 1\' in field (without \')\n\n" +
                "\t2. To Exit enter \'q\' in field (without \')\n\n" +
                "Enter \'q\' to return back to the main menu.");

            while (Console.ReadLine().Trim() != "q") { }
        }
    }
}
