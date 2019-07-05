using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabMenu
{
    public class PreferredCustomer : Customer
    {
        public PreferredCustomer(string name, string address, string phone, string id,
            string email, int spentAmount, bool onEmailList)
            : base (name, address, phone, id, email, spentAmount, onEmailList)
        {
            DiscountLevel = SetDiscountLevel();
        }

        public readonly decimal DiscountLevel;

        public decimal SetDiscountLevel()
        {
            int range = SpentAmount / 500;
            switch (range)
            {
                case 0:
                    return 0;
                    
                case 1:
                    return 0.05m;
                    
                case 2:
                    return 0.05m;
                    
                case 3:
                    return 0.08m;
                    
                default:
                    return 0.1m;
                    

            }
        }

        //public double GetDiscount()
        //{
        //    return SpentAmount * (double)DiscountLevel;
        //}

        //public override double CalcAmount()
        //{
        //    return base.CalcAmount() - GetDiscount();
        //}

        public override string ToString()
        {
            return
                String.Format(
                    "CustomerID: {0}\nCustomer Name: {1}\nCustomerAddress: {2}\n" +
                    "Customer Phone: {3} \nCustomer Email: {4}" +
                    "Customer Spending: {5:C2}\nCustomer On Email List: {6}",
                    CustomerID, CustomerName, Address, Phone, CustomerEmail, SpentAmount, OnEmailList
                    );
        }

    }
}
