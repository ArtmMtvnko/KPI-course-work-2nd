namespace Barley_Break.GUI
{
    interface IBuilder
    {
        void BuildMenu();

        Menu GetMenu();
    }
    internal class StartMenuBuilder : IBuilder
    {
        private Menu _menu = new Menu();

        public StartMenuBuilder() => Reset();
        public void Reset() => _menu = new Menu();

        public void BuildMenu()
        {
            _menu.AddMenuItem("1", new NewGameCommand());
            _menu.AddMenuItem("2", new ContinueGameCommand());
            _menu.AddMenuItem("3", new RulesCommand());
        }

        public Menu GetMenu()
        {
            Menu result = _menu;

            Reset();

            return result;
        }
    }
}
