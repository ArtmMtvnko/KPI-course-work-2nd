using Barley_Break.GUI;
using Barley_Break.src;

namespace Barley_Break
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.Builder = new StartMenuBuilder();
            user.BuildMenu();

            user.Run();
        }
    }
}