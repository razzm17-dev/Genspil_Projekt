using System;
using System.Collections.Generic;
using System.Text;

namespace Genspil_Projekt
{
    public class GameEdition
    {
        private string _edition;
        private string _quality;
        private double _price;
        private double _basePrice;

        public string Edition
        {
            get { return _edition; }
            set { _edition = value; }
        }

        public string Quality
        {
            get { return _quality; }
            set { _quality = value; }
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

        public GameEdition(string Edition, string Quality, double BasePrice, Game game)
        {
            _edition = Edition;
            _quality = Quality;
            _basePrice = BasePrice;
            _price = CalculatePrice();
        }

        5 % ikke åbnet
        15 % god stand
        25 % Ok stand
        50 % dårlig stand

        public double CalculatePrice();
        {
        

        }


    }
}
