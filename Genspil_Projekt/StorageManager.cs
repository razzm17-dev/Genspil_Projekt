using System;
using System.Collections.Generic;
using System.Text;

namespace Genspil_Projekt
{
    internal class StorageManager
    {
        private List<Game> _gameList;
        private List<Request> _requestList;

        public StorageManager()
        {
            // Uden de her to linjer er listerne 'null' (de findes ikke i hukommelsen)
            _gameList = new List<Game>();
            _requestList = new List<Request>();
        }

        /*public void AddGame(Game game)
        {
            if (_gameList.Count() > 1)
            {
                _gameList.Add(game);
            }
            else
            {
                _gameList.Add(game);
                _gameList = _gameList.OrderBy(game => game.Name).ToList();
            }
        }*/


        public void AddGame(Game game)
        {
            if (game == null) return;
           if (!_gameList.Contains(game))
            {
                _gameList.Add(game);
                _gameList = _gameList.OrderBy(game => game.Name).ToList();
            }
        }

        public void RemoveGame(Game game) 
        { 
            if (_gameList.Count() > 0) 
            { 
                _gameList.Remove(game);
            }
        }


        // søger efter navn på et enektl spil 
        public Game SearchForName(string name)
        {
            Console.WriteLine($"Søgte efter: '{name}'");

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Søgen er tom eller kun mellemrum. Ingen søgning udført.");
                return null;
            }

            foreach (var g in _gameList)
            {
                Console.WriteLine($"Tjekker: '{g.Name ?? "NULL"}'");
                if (g.Name != null && g.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Match fundet: {g.Name} - Antal: {g.Amount}");
                    // Print editions under spillet
                    g.GetAvailableEditions();
                    return g;
                }
            }

            Console.WriteLine("Intet match fundet.");
            return null;
        }


        public List<Game> SearchForGenre(string genre)
        {
            Console.WriteLine($"Søger efter den gældende genre: {genre} \n");

            var matches = new List<Game>();

            if (string.IsNullOrWhiteSpace(genre))
            {
                Console.WriteLine("Søgen er tom eller kun mellemrum: Udyldigt søgning");
                return matches;
            
            }
            
            foreach(var g in _gameList)
            {
                Console.WriteLine($"Tjekker {g.Genre} og finder navn: {g.Name}");
                if (g.Genre != null && g.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Match fundet: {g.Name} - Genre: {g.Genre} - Antal: {g.Amount}");
                    g.GetAvailableEditions();
                    matches.Add(g);
                }

             

            }

            if (matches.Count == 0) Console.WriteLine("Kunne ikke finde et match på genre.");
            return matches;
        }





        /*public void AddRequest(Request request)
        {
            if (_requestList.Count() < 0)
            {
                _requestList.Add(request);
            }
            else
            {
                _requestList.Add(request);
                _requestList = _requestList.OrderBy(request => request.Date).ToList();
            }
        }*/

        public void AddRequest(Request request)
        {
            if (request == null) return; 
            {
                _requestList.Add(request);
                _requestList = _requestList.OrderBy(r =>r.Date).ToList();
            }
            
            
        }




        public void RemoveRequest(Request request)
        {
            if (_requestList.Count() > 0)
            {
                _requestList.Remove(request);
            }
        }

        /* public void PrintGameList()
         {
             foreach (Game game in _gameList)
             {
                 Console.WriteLine($"Name: {game.Name}\nGenre: {game.Genre}\nPlayer Count: {game.PlayerCount} \nAntal: {game.Amount}");
             }
         }*/

        //Printer alle game
        public IEnumerable<Game> GetAllGames() => _gameList.AsReadOnly();

        // Printer alle requets
        public IEnumerable<Request> GetAllRequests() => _requestList.AsReadOnly();


        // printer både game og edition ud sammen
        public void PrintGameList()
        {
            foreach (Game game in _gameList)
            {
                Console.WriteLine($"Name: {game.Name}\nGenre: {game.Genre}\nPlayer Count: {game.PlayerCount} \nAntal: {game.Amount}");
                game.GetAvailableEditions();// printer Editions ind under Game list. 
                Console.WriteLine();
            }
        }


    }
}
