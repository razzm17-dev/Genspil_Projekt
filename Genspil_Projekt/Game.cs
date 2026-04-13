using System;
using System.Globalization;

namespace Genspil_Projekt
{
    public class Game
    {
        private string _name;
        private string _genre;
        private string _playerCount;
        private int _amount;

        public List<GameEdition> _editionList;

        public string Title { get; set; }

        public string Name
        { 
        get { return _name; }
        set { _name = value; }
        }

        public string Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }
        public string PlayerCount
        {
            get { return _playerCount; }
            set { _playerCount = value; }
        }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public Game(string name, string genre, string playerCount)
        {
            Name = name;
            Genre = genre;
            PlayerCount = playerCount;
            Amount = 0;
            _editionList = new List<GameEdition>();
        }

        // Tilføjer edition hvis den ikke allerede findes (sammenligner Edition, Condition og Price) eller retter antallet hvis den findes
        public void AddEdition(GameEdition edition)
        {
            if (edition == null) return;

            bool exists = _editionList.Any(ed =>
                string.Equals(ed.Edition, edition.Edition, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(ed.Condition, edition.Condition, StringComparison.OrdinalIgnoreCase) &&
                ed.Price == edition.Price);

            if (!exists)
            {
                _editionList.Add(edition);
                Amount = _editionList.Count;
            }
        }

        public void GetAvailableEditions()
        {
            foreach (var ed in _editionList)
            {
            Console.WriteLine ($"Udgave: {ed.Game._name} {ed.Edition} | Stand: {ed.Condition} | Pris: {ed.Price} kr. | Antal: {Amount}");
            }
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture,
                "GAME,{0},{1},{2},{3}", // Tilføjet "GAME"
                Name, Genre, PlayerCount, Amount);
        }

        public static Game FromString(string data)
        {
            string[] parts = data.Split(',');
            // parts[0] er "GAME"
            string name = parts[1];
            string genre = parts[2];
            string playerCount = parts[3];
            // parts[4] er Amount, men den genberegnes ofte automatisk

            return new Game(name, genre, playerCount);
        }
    }
}