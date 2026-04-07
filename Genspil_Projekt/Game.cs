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

        

        public List<GameEdition> GetAvailableEditions()
        {
            return _editionList;
        }

        public void addEdition(GameEdition edition)
        {
            
            _editionList.Add(edition);
            _amount++;
        }



    }
}
