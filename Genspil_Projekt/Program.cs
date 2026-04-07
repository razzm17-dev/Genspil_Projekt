namespace Genspil_Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StorageManager storage = new StorageManager();

            Game game1 = new Game("Daybreak", "Samarbejde", "2-8");
            GameEdition edition1 = new GameEdition("Engelsk", "God Stand", 650, game1);
            game1.addEdition(edition1);

            Console.WriteLine(game1.GetAvailableEditions());


            Console.ReadLine();

        }
    }
}
