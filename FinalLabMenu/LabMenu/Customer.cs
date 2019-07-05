using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabMenu
{
    public class Customer : Person
    {
        public Customer(string name, string address, string phone, string id, string email, int spentAmount,
            bool onEmailList)
            : base(name, address, phone)
        {
            CustomerID = id;
            CustomerEmail = email;
            SpentAmount = spentAmount;
            OnEmailList = onEmailList;
        }

        public string CustomerID { get; set; }
        public string CustomerEmail { get; set; }
        public int SpentAmount { get; set; }
        public bool OnEmailList { get; set; }

        public virtual double CalcAmount()
        {
            return SpentAmount;
        }
    }
}
