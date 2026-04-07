using System;
using System.Collections.Generic;
using System.Text;

namespace Genspil_Projekt
{
    public class Game
    {
        private string _name;
        private string _genre;
        private int _playerCount;

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
        public int PlayerCount
        {
            get { return _playerCount; }
            set { _playerCount = value; }
        }


        public Game(string name, string genre, int playerCount)
        {
            Name = name;
            Genre = genre;
            PlayerCount = playerCount;
        
        }

        public bool IsAvailable()
        {
            if (_editionList.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            } 
        }

        public List<GameEdition> GetAvailableEditions()
        {
            return _editionList;
        }


    }
}
