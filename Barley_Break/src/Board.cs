using System.Text.Json;

namespace Barley_Break.src
{
    abstract class GameBoard : IBoardPrototype, IObserve
    {
        protected const string _path = "D:\\Microsoft Visual Studio\\Projects\\OP_2nd_Course\\Course_work\\Barley_Break\\Barley_Break\\data\\save.json";

        protected List<List<int>> _board;

        public List<List<int>> Board => _board;

        private List<IObserver> _observers = new List<IObserver>();

        public string Clone()
        {
            return JsonSerializer.Serialize(this);
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(this._board);
            using (StreamWriter sr = new StreamWriter(_path))
            {
                sr.WriteLine(json);
            }
        }

        public string Parse()
        {
            using (StreamReader sr = new StreamReader(_path))
            {
                string output = String.Empty;
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    output += line;
                }

                return output;
            }
        }

        public void PrintBoard()
        {
            foreach (List<int> list in _board)
            {
                foreach (int number in list)
                {
                    if (number < 10)
                    {
                        Console.Write(" {0} ", number);
                    }
                    else
                    {
                        Console.Write("{0} ", number);
                    }
                }
                Console.WriteLine();
            }
        }

        public bool IsGameEnded()
        {
            int size = _board.Count;
            int lastEmptySquare = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                 {
                    if (_board[i][j] != (i * size + j + 1))
                    {
                        if (_board[size - 1][size - 1] == lastEmptySquare)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }

            return true;
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update(this);
            }
        }

        public abstract void Move(int fromX, int fromY, int toX, int toY);

        public IMemento CreateBackup()
        {
            return new CurrentBoardMemento(this);
        }

        public void Restore(IMemento memento)
        {
            _board = memento.State;
        }
    }


    internal class DefaultBoard : GameBoard
    {
        //public int VerticalSize { get; } = 4;

        //public int HorisontalSize { get; } = 4;

        // TODO: Make random generation
        public DefaultBoard()
        {
            _board = new List<List<int>>();
            _board.Add(new List<int>() { 1, 2, 3, 4 });
            _board.Add(new List<int>() { 5, 6, 7, 8 });
            _board.Add(new List<int>() { 9, 10, 11, 12 });
            _board.Add(new List<int>() { 13, 14, 0, 15 });
        }

        public DefaultBoard(string json)
        {
            _board = JsonSerializer.Deserialize<List<List<int>>>(json);
        }

        public override void Move(int fromX, int fromY, int toX, int toY)
        {
            // TODO: may be move backup caretaker here and save snapshot before we move elements
            int temp = _board[toY][toX];
            _board[toY][toX] = _board[fromY][fromX];
            _board[fromY][fromX] = temp;
            Notify();
        }
    }
}
