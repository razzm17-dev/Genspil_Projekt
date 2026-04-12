using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Genspil_Projekt
{
    public class Request
    {
        private string _name, _status;
        private string _contactInfo;
        private DateTime _date;
        private string _customerCriteria;

        public string Name { get => _name; set => _name = value; }
        public string Status { get => _status; set => _status = value; }
        public string ContactInfo { get => _contactInfo; set => _contactInfo = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public string CustomerCriteria { get => _customerCriteria; set => _customerCriteria = value; }

        public Request(string name, string contactInfo, DateTime date, string customerCriteria)
        {
            _name = name;
            _contactInfo = contactInfo;
            _date = date;
            _customerCriteria = customerCriteria;
        }
        public override string ToString()
        {
            // Vi bruger InvariantCulture for at tvinge punktum som decimaltegn (f.eks. 18.2 i stedet for 18,2)
            // Dette sikrer, at filen kan læses på alle computere.
            return string.Format(CultureInfo.InvariantCulture,
                "{0},{1},{2},{3}",
                Name, ContactInfo, Date, CustomerCriteria);
        }

        public static Request FromString(string data)
        {
            string[] parts = data.Split(',');
            {
                string Name = parts[0];
                string ContactInfo = parts[1];
                DateTime Date = DateTime.Parse(parts[2]);
                string CustomerCriteria = parts[3];


                return new Request(Name, ContactInfo, Date, CustomerCriteria);
            }


        }

    }
}
