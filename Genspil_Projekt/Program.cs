namespace Genspil_Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StorageManager storage = new StorageManager();
           


            Game game1 = new Game("Daybreak", "Samarbejde", "2-8");
            GameEdition edition1 = new GameEdition("Engelsk", "god stand", 650, game1);
            game1.addEdition(edition1);
            storage.AddGame(game1);

            Game game2 = new Game("Daybreak", "Samarbejde", "2-8");
            GameEdition edition2 = new GameEdition("Engelsk", "god stand", 650, game2);
            game2.addEdition(edition2);
            storage.AddGame(game2);





            //storage.PrintGameList();
            storage.SearchForName("daybreak");
            storage.SearchForGenre("samarbejde");
            Console.ReadLine();

        }
    }
}
