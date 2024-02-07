namespace Barley_Break.src
{
    internal class DefaulBoardController : GameBoard
    {
        private GameBoard _board;

        public void SetBoard(GameBoard board) { _board = board; }

        public override void Move(int x, int y, int toX = 0, int toY = 0)
        {
            if (_board.Board[y][x] == 0)
            {
                throw new Exception();
            }
            if (y < 3 && _board.Board[y + 1][x] == 0)
            {
                _board.Move(x, y, x, y + 1);
            }
            if (y > 0 && _board.Board[y - 1][x] == 0)
            {
                _board.Move(x, y, x, y - 1);
            }
            if (x < 3 && _board.Board[y][x + 1] == 0)
            {
                _board.Move(x, y, x + 1, y);
            }
            if (x > 0 && _board.Board[y][x - 1] == 0)
            {
                _board.Move(x, y, x - 1, y);
            }
        }
    }
}
