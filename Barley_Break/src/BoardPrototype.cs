namespace Barley_Break.src
{
    internal interface BoardPrototype
    {
        string Clone();

        void Save(string json);
    }
}
