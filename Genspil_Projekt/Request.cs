using System;
using System.Collections.Generic;
using System.Text;

namespace Genspil_Projekt
{
    internal class Request
    {
        private string _name, _status;
        private int _contactInfo;
        private DateTime _date;
        private string _customerCriteria;

        public string Name { get => _name; set => _name = value; }
        public string Status { get => _status; set => _status = value; }
        public int ContactInfo { get => _contactInfo; set => _contactInfo = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public string CustomerCriteria { get => _customerCriteria; set => _customerCriteria = value; }

        public Request(string name, string status, int contactInfo, DateTime date, string customerCriteria)
        {
            _name = name;
            _status = status;
            _contactInfo = contactInfo;
            _date = date;
            _customerCriteria = customerCriteria;
        }

        public void GetRequestDetails() 
        { 
            Console.WriteLine($"Name: {_name}\nStatus: {_status}\nContact Info: {_contactInfo}\nDate: {_date}\nCustomer Criteria: {_customerCriteria}");
        }
    }
}
