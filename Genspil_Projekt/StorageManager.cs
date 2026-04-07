using System;
using System.Collections.Generic;
using System.Text;

namespace Genspil_Projekt
{
    internal class StorageManager
    {
        private List<Game> _gameList;
        private List<Request> _requestList;

        public void AddGame(Game game)
        {
            if (_gameList.Count() < 0)
            {
                _gameList.Add(game);
            }
            else
            {
                _gameList.Add(game);
                _gameList = _gameList.OrderBy(game => game.Name).ToList();
            }
        }
    }
}
