using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.IO;

namespace Genspil_Projekt
{
    public class DataHandler
    {


        public string FilePath { get; set; }

        public DataHandler(string filePath)
        {
            FilePath = filePath;

        }
        /*public void SaveGamesToFile(List<Game> games)
        {

            using (StreamWriter sw = new StreamWriter(FilePath)) // Åbner filen til skrivning
            {

                foreach (var game in games)
                {
                    sw.WriteLine(game.ToString());// Gemmer hver medarbejder som en linje i filen

                }


            }

        }*/


        public void SaveGamesToFile(List<Game> games)
        {

            using (StreamWriter sw = new StreamWriter(FilePath)) // Åbner filen til skrivning
            {


                foreach (var game in games)
                {
                    sw.WriteLine(game.ToString());

                    foreach (var edition in game._editionList)
                    {
                        sw.WriteLine(edition.ToString());// Gemmer hver medarbejder som en linje i filen

                    }

                }
            }

        }

        public void SaveRequestsToFile(List<Request> requests)
        {

            using (StreamWriter sw = new StreamWriter(FilePath)) // Åbner filen til skrivning
            {

                foreach (var request in requests )
                {
                    sw.WriteLine(request.ToString());// Gemmer hver medarbejder som en linje i filen

                }


            }

        }


        public List<Game> LoadOnlyGames()
        {
            List<Game> games = new List<Game>();
            foreach (string line in File.ReadAllLines(FilePath))
            {
                if (line.StartsWith("GAME")) // Vi ignorerer alle linjer der starter med EDITION
                {
                    games.Add(Game.FromString(line));
                }
            }
            return games;
        }





        public List<Game> LoadEverything()
        {
            List<Game> games = new List<Game>();
            Game lastGame = null;

            if (!File.Exists(FilePath)) return games;

            string[] lines = File.ReadAllLines(FilePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(',');
                string type = parts[0];

                if (type == "GAME")
                {
                    lastGame = Game.FromString(line);
                    games.Add(lastGame);
                }
                else if (type == "EDITION" && lastGame != null)
                {
                    // Her sender vi 'lastGame' med som parameter
                    GameEdition edition = GameEdition.FromString(line, lastGame);

                    // Tilføj udgaven til spillets egen liste
                    lastGame.AddEdition(edition);
                }
            }
            return games;
        }





        // request Load
        public List<Request> LoadRequestFromFile()
        {
            List<Request> request = new List<Request>();

            using (StreamReader sr = new StreamReader(FilePath)) //Åbner filen til læsning
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        // Vi kigger på den første del af linjen for at se typen
                        request.Add(Request.FromString(line));


                    }
                }

            }

            return request;
        }




    }
}
