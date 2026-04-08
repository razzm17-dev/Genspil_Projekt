using System;
using System.Collections.Generic;
using System.Text;

namespace Genspil_Projekt
{
    public class Game
    {
        private string _name;
        private string _genre;
        private string _playerCount;
        private int _amount;

        private List<GameEdition> _editionList;

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
            Amount =0;
            _editionList = new List<GameEdition>();
        }

        

        public void GetAvailableEditions()
        {
            foreach (var ed in _editionList)
            {
            Console.WriteLine ($"Udgave: {ed.Edition}, Stand: {ed.Condition}, Pris: {ed.Price} kr.\n");

            }
        }

        // Returnerer editions som en læsbar samling så StorageManager kan iterere
        public IEnumerable<GameEdition> GetEditions()
        {
            return _editionList.AsReadOnly();
        }


        // Tilføjer edition hvis den ikke allerede findes (sammenligner Edition, Condition og Price)
        public void addEdition(GameEdition edition)
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
    }
}



    

