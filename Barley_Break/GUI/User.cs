namespace Barley_Break.GUI
{
    internal class User
    {
        private IBuilder _builder;
        private Menu _menu;

        public IBuilder Builder
        {
            set { _builder = value; }
        }

        public void BuildMenu()
        {
            _builder.BuildMenu();
            _menu = _builder.GetMenu();
        }

        private void DrawMenu()
        {
            _menu.DrawMenu();
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                DrawMenu();
                string inputKey = Console.ReadLine().Trim();
                _menu.Execute(inputKey);
            }
        }
    }
}
