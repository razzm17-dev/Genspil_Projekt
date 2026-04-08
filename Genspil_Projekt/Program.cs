namespace Genspil_Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {


            StorageManager storage = new StorageManager();
            
            Game game2 = new Game("ExplodingKittens", "CardGame", "2-8");
            GameEdition EKedition1 = new GameEdition("Engelsk", "ok stand", 450, game2);
            game2.addEdition(EKedition1);
            storage.AddGame(game2);

            Game game1 = new Game("Daybreak", "Samarbejde", "2-8");
            GameEdition DBedition1 = new GameEdition("Engelsk", "god stand", 650, game1);
            game1.addEdition(DBedition1);
            storage.AddGame(game1);


            GameEdition DBedition2 = new GameEdition("Engelsk", "god stand", 650, game1);
            game1.addEdition(DBedition2);
            storage.AddGame(game1);



            while (true)
            {
                Console.Clear();
                Console.WriteLine("");

                int valg = storage.Menu(new List<string>
                {
                    "Opret spil",
                    "Slet spil",
                    "Tilføj Spiludgave",
                    "Søg efter spil",
                    "Opret forespørgsel",
                    "Slet forespørgsel",
                    "Udskriv optællingsliste"
                });

                switch (valg)
                {
                    case 1:
                        storage.AddGameFromUserInput();
                        break;
                    case 2:
                        storage.RemoveGameFromUserInput();
                        break;
                    /*case 3:
                        storage.AddGameEditionFromUserInput();
                        break;*/
                    case 4:
                        Console.Clear();
                        Console.Write("Indtast søgekriterier ");
                        string query = Console.ReadLine();
                        storage.SearchForGame(query);
                        break;
                    case 5:
                        storage.AddRequestFromUserInput();
                        break;
                     case 6:
                         storage.RemoveRequestFromUserInput();
                         break;
                    case 7:
                        storage.PrintGameList();
                        break;
                    case 8:
                        Console.WriteLine("Afslut");
                        return;
                }


               // storage.SearchForGame("day");



                //storage.PrintGameList();
                //storage.SearchForName("daybreak");
                //storage.SearchForGenre("samarbejde");
                Console.ReadLine();

            }
        }
    }
}
