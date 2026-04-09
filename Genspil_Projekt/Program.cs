namespace Genspil_Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {


            StorageManager storage = new StorageManager();

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
                    "Se alle forespørgsler",
                    "Udskriv optællingsliste",
                    "Afslut"
                });

                switch (valg)
                {
                    case 1:
                        storage.AddGameFromUserInput();
                        break;
                    case 2:
                        storage.RemoveGameFromUserInput();
                        break;
                    case 3:
                        storage.CreateEditionFromUserInput();
                        break;
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
                        storage.PrintRequestList();
                        break;
                    case 8:
                        storage.PrintGameList();
                        break;
                    case 9:
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
