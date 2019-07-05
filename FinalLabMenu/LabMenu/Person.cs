using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabMenu
{
    public class Person
    {
        public Person(string name, string address, string phone)
        {
            CustomerName = name;
            Address = address;
            Phone = phone;
        }

        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
