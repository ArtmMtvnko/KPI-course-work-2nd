namespace Barley_Break.GUI
{
    internal class Menu
    {
        private Dictionary<string, ICommand> _items = new Dictionary<string, ICommand>();

        public Dictionary<string, ICommand> Items => _items;

        public void AddMenuItem(string number, ICommand command)
        {
            _items.Add(number, command);
        }

        public void DrawMenu()
        {
            foreach (var item in _items)
            {
                Console.WriteLine($"\t{item.Key}  {item.Value.Name}");
            }
        }

        public void Execute(string key)
        {
            _items[key].Execute();
        }
    }
}
