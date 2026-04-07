using System;
using System.Collections.Generic;
using System.Text;

namespace Genspil_Projekt
{
    public class GameEdition
    {
        private string _edition;
        private string _quality;
        private double price;
        private double _basePrice; 

        public GameEdition(string edition, string quality, double basePrice)
        {
            _edition = edition;
            _quality = quality;
            _basePrice = basePrice;
            price = CalculatePrice();
        }   

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
            get { return price; }
        }



        {
    }
}
