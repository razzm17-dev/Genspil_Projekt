namespace Genspil_Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataHandler gameHandler = new DataHandler("games.txt");
            DataHandler requestHandler = new DataHandler("requests.txt");

            StorageManager storage = new StorageManager();

            // 2. LOAD: Hent gemte data ind i programmet med det samme
            List<Game> loadedGames = gameHandler.LoadEverything();
            foreach (var g in loadedGames) storage.AddGameToList(g);

            List<Request> loadedRequests = requestHandler.LoadRequestsFromFile();
            foreach (var r in loadedRequests) storage.AddRequest(r);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("");

                int valg = storage.Menu(new List<string>
                {
                    "Opret spil",
                    "Slet spil",
                    "Tilføj Spiludgave",
                    "Slet Spiludgave",
                    "Søg efter spil",
                    "Opret forespørgsel",
                    "Slet forespørgsel",
                    "Se alle forespørgsler",
                    "Udskriv optællingsliste",
                    "Udskriv games og editions",
                    "Afslut"
                });

                switch (valg)
                {
                    case 1:
                        storage.AddGameFromUserInput();
                        gameHandler.SaveGamesToFile(storage.GetGameList());
                        break;
                    case 2:
                        storage.RemoveGameFromUserInput();
                        gameHandler.SaveGamesToFile(storage.GetGameList());
                        break;
                    case 3:
                        storage.CreateEditionFromUserInput();
                        gameHandler.SaveGamesToFile(storage.GetGameList());
                        break;
                    case 4:
                        storage.RemoveEditionFromUserInput();
                        gameHandler.SaveGamesToFile(storage.GetGameList());
                        break;
                    case 5:
                        Console.Clear();
                        Console.Write("Indtast søgekriterier ");
                        string query = Console.ReadLine();
                        storage.SearchForGame(query);
                        break;
                    case 6:
                        storage.AddRequestFromUserInput();
                        requestHandler.SaveRequestsToFile(storage.GetRequestList());
                        break;
                    case 7:
                        storage.RemoveRequestFromUserInput();
                        requestHandler.SaveRequestsToFile(storage.GetRequestList());
                        break;
                    case 8:
                        Console.Clear();
                        storage.PrintRequestList();
                        break;
                    case 9:
                        Console.Clear();
                        storage.PrintGameList();
                        break;
                    case 10:
                        Console.Clear();
                        storage.PrintGameAndEditionList();
                        break;
                    case 11:
                        Console.WriteLine("Afslut");
                        return;
                }
                Console.ReadLine();
            }
        }
    }
}
