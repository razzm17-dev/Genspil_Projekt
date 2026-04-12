using System;
using System.Globalization;

namespace Genspil_Projekt
{
    public class GameEdition
    {
        private string _edition;
        private string _condition;
        private double _price;
        private double _basePrice;
        public Game Game { get; set; }

        public string Edition
        {
            get { return _edition; }
            set { _edition = value; }
        }

        public string Condition
        {
            get { return _condition; }
            set { _condition = value; }
        }

        public double BasePrice
        {
            get { return _basePrice; }
            set { _basePrice = value; }

        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public GameEdition(string Edition, string Condition, double BasePrice, Game game)
        {
            _edition = Edition;
            _condition = Condition;
            _basePrice = BasePrice;
            _price = CalculatePrice(BasePrice, Condition);
            Game = game;
        }

        //5 % ikke åbnet
        //15 % god stand
        //25 % Ok stand
        //50 % dårlig stand

        // Metode til at beregne prisen baseret på stand og basepris
        static double CalculatePrice(double BasePrice, string Condition)
        {
            double discount = 0;

            switch (Condition.ToLower())
            {
                case "ikke åbnet":
                    discount = 0.05;
                    break;
                case "god stand":
                    discount = 0.15;
                    break;
                case "ok stand":
                    discount = 0.25;
                    break;
                case "dårlig stand":
                    discount = 0.50;
                    break;
            }

            return BasePrice * (1 - discount);
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture,
                "EDITION,{0},{1},{2},{3}", // Tilføjet "EDITION"
                Edition, Condition, BasePrice, Price);
        }

        public static GameEdition FromString(string data, Game parentGame)
        {
            string[] parts = data.Split(',');
            // parts[0] er "EDITION"
            string editionName = parts[1];
            string condition = parts[2];
            double basePrice = double.Parse(parts[3], CultureInfo.InvariantCulture);

            return new GameEdition(editionName, condition, basePrice, parentGame);
        }
    }
}   