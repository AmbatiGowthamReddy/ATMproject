using ATMDataAccess;
using ATMProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public class Customer
    {
        CustomerInfo c;
        private ATMDataModel dataModel;
        public CustomerInfo GetCustomerDetails(int cardNumber)
        {
            try
            {
                dataModel = new ATMDataModel();
                var cardData = dataModel.Cards.SingleOrDefault(p => p.CardNumber == cardNumber);
                if (cardData != null)
                {
                    c = new CustomerInfo();
                    c.CustomerId = cardData.CustomerId;
                    var custData = dataModel.Customers.SingleOrDefault(p => p.CustomerId == c.CustomerId);
                    if (custData != null)
                    {
                        c.CustomerName = custData.CustomerName;
                        c.CustomerAddress = custData.CustomerAddress;
                    }
                }
                return c;
            }
            catch (Exception E)
            {
                throw E;
            }

        }
    }
}
