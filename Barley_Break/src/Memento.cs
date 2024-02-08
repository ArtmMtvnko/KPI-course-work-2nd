﻿using System.Text.Json;

namespace Barley_Break.src
{
    internal interface IMemento
    {
        List<List<int>> State { get; set; }
    }

    class CurrentBoardMemento : IMemento
    {
        private List<List<int>> _state;
        public List<List<int>> State
        {
            get { return _state; }
            set { _state = value; }
        }

        public CurrentBoardMemento(GameBoard gameBoard)
        {
            string json = JsonSerializer.Serialize(gameBoard.Board);
            _state = JsonSerializer.Deserialize<List<List<int>>>(json);
        }
    }

    class Caretaker
    {
        private List<IMemento> _mementos = new List<IMemento>();

        private GameBoard _gameBoard;

        public Caretaker(GameBoard gameBoard) => _gameBoard = gameBoard;

        public void Backup()
        {
            if (_mementos.Count > 10)
            {
                _mementos.RemoveAt(0);
                _mementos.Add(_gameBoard.CreateBackup());
            } 
            else
            {
                _mementos.Add(_gameBoard.CreateBackup());
            }
        }

        public void Undo()
        {
            if (_mementos.Count == 0) return;

            IMemento last = _mementos.Last();
            _mementos.Remove(last);

            _gameBoard.Restore(last);
        }
        // TODO: create private var Caretaker in Controller (new Caretaker make in constructor of controller)
        public void ShowHistory()
        {
            foreach (IMemento memento in _mementos)
            {
                foreach (List<int> list in memento.State)
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
                Console.WriteLine("----------");
            }
        }
    }
}
