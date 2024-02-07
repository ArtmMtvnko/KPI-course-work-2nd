namespace Barley_Break.src
{
    internal interface IBoardPrototype
    {
        string Clone();

        void Save();

        string Parse();
    }
}
