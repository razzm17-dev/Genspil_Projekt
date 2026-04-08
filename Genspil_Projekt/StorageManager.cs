using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        // Menu metode som tager en liste af string og lader brugeren vælge imellem dem ved hjælp af piletasterne. Returnerer det valgte nummer.
        public int Menu(List<string> mulighedstext)
        {
            int valg = 1;
            ConsoleKeyInfo tast;
            bool valgtSwitch = false;
            string farve = "\u001b[32m";

            //Sørger for at vores menu starter på det samme sted hver gang. 
            int topafmenu = Console.CursorTop;
            while (!valgtSwitch)
            {
                Console.SetCursorPosition(0, topafmenu);

                for (int i = 0; i < mulighedstext.Count(); i++) 
                {
                    int nummer = i + 1;
                    Console.WriteLine($"{(valg == nummer ? farve : "")} {nummer}. {mulighedstext[i]}\u001b[0m");
                }

                tast = Console.ReadKey(true);

                switch (tast.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (valg >= mulighedstext.Count())
                        {
                            valg = 1;
                        }
                        else
                        {
                            valg++;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (valg > 1)
                        {
                            valg--;
                        }
                        else
                        {
                            valg = mulighedstext.Count();
                        }
                        break;

                    case ConsoleKey.Enter:
                        valgtSwitch = true;
                        break;
                }
            }

            return valg;
        }


        //Lader bruger indtaste oplysninger om et spil og opretter et game objekt. Anvender herefter AddGame for at tilføje det til listen.
        public void AddGameFromUserInput()
        {
            Console.Clear();
            Console.Write("Indtast spilnavn: ");
            string name = Console.ReadLine();

            Console.Write("Indtast genre: ");
            string genre = Console.ReadLine();

            Console.Write("Indtast antal spillere (fx 2 eller 2-4): ");
            string playerCount = Console.ReadLine();

            Game newGame = new Game(name,genre,playerCount)
            {
                Name = name,
                Genre = genre,
                PlayerCount = playerCount
            };

            AddGame(newGame);

            Console.WriteLine("Spillet er tilføjet.");
        }
        //Tilføjer et spil til listen og sorterer i listen alfabetisk efter spillets navn. 
        public void AddGame(Game game)
        {
            if (game == null) return;
           if (!_gameList.Contains(game))
            {
                _gameList.Add(game);
                _gameList = _gameList.OrderBy(game => game.Name).ToList();
            }
        }
        //Opretter liste over spil som brugeren kan vælge imellem. 
        public Game SelectGameFromList()
        {
            if (_gameList.Count == 0)
            {
                Console.WriteLine("Der er ingen spil i listen.");
                return null;
            }

            List<string> gameNames = _gameList
                .Select(g => $"{g.Name} ({g.Genre})")
                .ToList();

            Console.WriteLine("Vælg et spil:");

            int valg = Menu(gameNames); 

            return _gameList[valg - 1];
        }
        //Lader brugeren vælge et spil fra listen og anvender RemoveGame til at fjerne det derefter.
        public void RemoveGameFromUserInput()
        {
            Console.Clear();

            Game selected = SelectGameFromList();
            if (selected == null)
            {
                Console.WriteLine("Ingen spil valgt.");
                return;
            }

            RemoveGame(selected);
            Console.WriteLine($"Spillet '{selected.Name}' er nu fjernet fra listen.");
        }
        //Sletter et spil fra listen. 
        public void RemoveGame(Game game) 
        { 
            if (_gameList.Count() > 0) 
            { 
                _gameList.Remove(game);
            }
        }

        // Fleksibel søgning på navn, genre, maxPrice og playerCount
        // Indsæt i StorageManager (kræver using System.Linq;)
        // Placer i StorageManager.cs (kræver using System.Linq;)
        public List<Game> SearchForGame(string query)
        {
            var results = new List<Game>();

            if (string.IsNullOrWhiteSpace(query))
            {
                Console.WriteLine("Der blev ikke indtastet nogle kriterier");
                return results;
            }

            query = query.Trim();

            // 1) Først: delvis match på navn (case-insensitive)
            var nameMatches = _gameList
                .Where(g => !string.IsNullOrWhiteSpace(g.Name) &&
                            g.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            if (nameMatches.Count > 0)
            {
                Console.WriteLine($"Navnsmatch for '{query}' — fundet {nameMatches.Count} spil:");
                foreach (var g in nameMatches)
                {
                    Console.WriteLine($"{g.Name} - {g.Genre} - {g.PlayerCount}");
                    g.GetAvailableEditions();
                    results.Add(g);
                }
                return results;
            }

            // 2) Hvis ingen navnsmatch, prøv delvis match på genre (case-insensitive)
            var genreMatches = _gameList
                .Where(g => !string.IsNullOrWhiteSpace(g.Genre) &&
                            g.Genre.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            if (genreMatches.Count > 0)
            {
                Console.WriteLine($"Genre‑match for '{query}' — fundet {genreMatches.Count} spil:");
                foreach (var g in genreMatches)
                {
                    Console.WriteLine($"{g.Name} - {g.Genre} - {g.PlayerCount}");
                    g.GetAvailableEditions();
                    results.Add(g);
                }
            }
            else
            {
                Console.WriteLine($"Intet match fundet for '{query}' (hverken navn eller genre).");
            }

            return results;
        }


        // søger efter navn på et enektl spil 
        /*public Game SearchForName(string name)
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
         }*/

        // søger efter genre
        /*public List<Game> SearchForGenre(string genre)
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
        }*/
        // Lader brugeren indtaste oplysninger om en forespørgsel og opretter et request-objekt. Anvender herefter AddRequest for at tilføje det til listen.
        public void AddRequestFromUserInput()
        {
            Console.Clear();
            Console.WriteLine("Titel på spil: ");
            string title = Console.ReadLine();

            Console.WriteLine("Kontaktinformation: ");
            string contactinfo = Console.ReadLine();
            
            Console.WriteLine("Dato for forespørgsel: ");
            string dateInput = Console.ReadLine();

            if (!DateTime.TryParse(dateInput, out DateTime date))
            {
                Console.WriteLine("Ugyldig dato. Request blev ikke oprettet.");
                return;
            }

            // Opret request-objektet
            Request request = new Request(name: title, status: "Åben", contactInfo: contactinfo, date: date)
            {
                Name = title,
                Date = date

            };

            AddRequest(request);

            Console.WriteLine("Forespørgsel er tilføjet");
        }

        //Tilføjer en forespørgsel til listen og sorterer listen efter dato.
        public void AddRequest(Request request)
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
        }

        // Opretter liste over forespørgsler som brugeren kan vælge imellem.
        public Request SelectRequestFromList()
        {
            if (_requestList.Count == 0)
            {
                Console.WriteLine("Der er ingen aktive forespørgsler.");
                return null;
            }

            List<string> request = _requestList
                .Select(r => $"{r.Name} - {r.Date.ToShortDateString()}; Kontakt: {r.ContactInfo}")
                .ToList();

            //tilføjer muligheden for at annullere og vende tilbage til menuen.
            request.Add("Annuller");
            Console.WriteLine("Vælg en forespørgsel:");

            int valg = Menu(request);

            if (valg == request.Count)
                return null;

            return _requestList[valg - 1];
        }
        //Lader brugeren vælge en forespørgsel fra listen og anvender RemoveRequest til at fjerne den derefter.
        public void RemoveRequestFromUserInput()
        {
            Console.Clear();

            Request selected = SelectRequestFromList();
            if (selected == null)
            {
                Console.WriteLine("Ingen forespørgsler valgt, tryk enter for at returnere til menuen");
                return;
            }

            RemoveRequest(selected);
            Console.WriteLine($"Forespørslen'{selected.Name}' er nu fjernet fra listen.");
        }

        public void RemoveRequest(Request request)
         {
             if (_requestList.Count() > 0)
             {
                 _requestList.Remove(request);
             }
         }




        //Printer alle game
        public IEnumerable<Game> GetAllGames() => _gameList.AsReadOnly();

        // Printer alle requets
        public IEnumerable<Request> GetAllRequests() => _requestList.AsReadOnly();


        // printer både game og edition ud sammen
        public void PrintGameList()
        {
            foreach (Game game in _gameList)
            {
                Console.WriteLine($"Name: {game.Name}Genre: {game.Genre}Player Count: {game.PlayerCount}Antal: {game.Amount}");
                game.GetAvailableEditions();// printer Editions ud ind under Game list. 
                Console.WriteLine();
            }
        }


    }
}
