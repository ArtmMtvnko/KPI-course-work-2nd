namespace Barley_Break.src
{
    internal interface IObserver
    {
        void Update(GameBoard gameBoard);
    }

    interface IObserve
    {
        void Attach(IObserver observer);

        void Detach(IObserver observer);

        void Notify();
    }

    class MoveObserver : IObserver
    {
        public void Update(GameBoard gameBoard)
        {
            gameBoard.Save();
        }
    }
}
