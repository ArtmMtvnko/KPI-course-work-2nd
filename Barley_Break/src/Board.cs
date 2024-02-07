using System.Text.Json;

namespace Barley_Break.src
{
    abstract class GameBoard : BoardPrototype
    {
        protected const string _path = "D:\\Microsoft Visual Studio\\Projects\\OP_2nd_Course\\Course_work\\Barley_Break\\Barley_Break\\data\\save.json";

        protected List<List<int>> _board;

        public List<List<int>> Board => _board;

        public abstract string Clone();

        public abstract string Parse();

        public abstract void Save();

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
    }


    internal class DefaultBoard : GameBoard
    {
        public DefaultBoard()
        {
            _board = new List<List<int>>();
            _board.Add(new List<int>() { 1, 2, 3, 4 });
            _board.Add(new List<int>() { 5, 6, 7, 8 });
            _board.Add(new List<int>() { 9, 10, 11, 12 });
            _board.Add(new List<int>() { 13, 14, 15, 0 });
        }

        // TODO: Review posibility of moving up Clone(), Save(), Parse() to parent class

        public override string Clone()
        {
            return JsonSerializer.Serialize(this);
        }

        public override void Save()
        {
            string json = JsonSerializer.Serialize(this);
            using (StreamWriter sr = new StreamWriter(_path))
            {
                sr.WriteLine(json);
            }
        }
        // TODO: move path in parametrs in methods to avoid hardcoding
        public override string Parse()
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
    }
}
