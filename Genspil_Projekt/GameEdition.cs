using System;
using System.Collections.Generic;
using System.Text;

namespace Genspil_Projekt
{
    public class GameEdition
    {
        private string _edition;
        private string _condition;
        private double _price;
        private double _basePrice;

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
        }

        public GameEdition(string Edition, string Condition, double BasePrice, Game game)
        {
            _edition = Edition;
            _condition = Condition;
            _basePrice = BasePrice;
            _price = CalculatePrice( BasePrice,  Condition);
        }

        //5 % ikke åbnet
        //15 % god stand
        //25 % Ok stand
        //50 % dårlig stand


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


    }
}