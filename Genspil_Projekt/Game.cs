using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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

        //Lader brugeren vælge et spil fra listen over udgaver og returnerer det valgte spil. Hvis der ikke er nogen udgaver, informeres brugeren.
        public GameEdition SelectEditionFromList()
        {
            if (_editionList.Count == 0)
            {
                Console.WriteLine("Der er ingen editions for dette spil.");
                return null;
            }

            Console.WriteLine($"\nVælg en udgave af {Name}:");

            for (int i = 0; i < _editionList.Count; i++)
            {
                var ed = _editionList[i];
                Console.WriteLine($"{i + 1}) {ed.Edition} - {ed.Condition} - {ed.Price} kr.");
            }

            int choice;
            while (true)
            {
                Console.Write("Indtast nummer: ");
                if (int.TryParse(Console.ReadLine(), out choice) &&
                    choice >= 1 && choice <= _editionList.Count)
                {
                    return _editionList[choice - 1];
                }

                Console.WriteLine("Ugyldigt valg. Prøv igen.");
            }
        }

        //Fjerner udgave af spillet hvis den fines på listen. 
        public bool RemoveEdition(GameEdition edition)
        {
            if (edition == null) return false;

            bool removed = _editionList.Remove(edition);

            if (removed)
                Amount = _editionList.Count;

            return removed;
        }
        // Viser alle udgaver af spillet
        public void GetAvailableEditions()
        {
            foreach (var ed in _editionList)
            {
            Console.WriteLine ($"Udgave: {ed.Edition}, Stand: {ed.Condition}, Pris: {ed.Price} kr., Antal: {Amount}\n");

            }
        }
        
    }
}



    

