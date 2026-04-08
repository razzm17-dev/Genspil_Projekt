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


            storage.SearchForGame("day");



            //storage.PrintGameList();
            //storage.SearchForName("daybreak");
            //storage.SearchForGenre("samarbejde");
            Console.ReadLine();

        }
    }
}
