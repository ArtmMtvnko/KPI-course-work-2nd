using System.Text.Json;

namespace Barley_Break.src
{
    internal interface IBoardFactory
    {
        GameBoard CreateBoard();
    }

    class DefaultBoardFactory : IBoardFactory
    {
        private const string _path = "D:\\Microsoft Visual Studio\\Projects\\OP_2nd_Course\\Course_work\\Barley_Break\\Barley_Break\\data\\save.json";

        public GameBoard CreateBoard()
        {
            string json = String.Empty;

            using (StreamReader sr = new StreamReader(_path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    json += line;
                }
            }
            Console.WriteLine(json);
            return new DefaultBoard(json);
        }
    }
}
