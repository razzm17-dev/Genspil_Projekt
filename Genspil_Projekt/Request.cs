using System;
using System.Globalization;

namespace Genspil_Projekt
{
    public class Request
    {
        private string _name, _status;
        private string _contactInfo;
        private DateTime _date;
        private string _customerCriteria;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Status 
        { 
            get { return _status; }
            set { _status = value; }
        }
        public string ContactInfo 
        {
            get { return _contactInfo; }
            set { _contactInfo = value; }
        }
        public DateTime Date 
        {
            get { return _date; }
            set { _date = value; }
        }
        public string CustomerCriteria
        {
            get { return _customerCriteria; }
            set { _customerCriteria = value; }
        }

        public Request(string name, string contactInfo, DateTime date, string customerCriteria)
        {
            Name = name;
            ContactInfo = contactInfo;
            Date = date;
            CustomerCriteria = customerCriteria;
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
