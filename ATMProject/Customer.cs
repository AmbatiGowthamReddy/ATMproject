using ATMDataAccess;
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
        private int customerId { get; set; }
        private string customerName { get; set; }
        private string customerAddress { get; set; }

        private ATMDataModel dataModel;

        public string ShowCustomerDetails(int cardNumber)
        {
           
            string connString = ConfigurationManager.ConnectionStrings["ATMConnectionString"].ToString();
            dataModel = new ATMDataModel();
            var cardData = dataModel.Cards.SingleOrDefault(p => p.CardNumber == cardNumber);
            if (cardData != null)
            {
                this.customerId = cardData.CustomerId;
                var custData = dataModel.Customers.SingleOrDefault(p => p.CustomerId == customerId);
                if (custData != null)
                {
                    this.customerName = custData.CustomerName;
                    this.customerAddress = custData.CustomerAddress;
                    var CustomerDetails = $"CustomerId={customerId}, CustomerName= {customerName}, CustomerAddress= {customerAddress}";
                    return CustomerDetails;
                }
                return "Customer is not avaible with give CardNumber";
            }
            return "Enter Correct Customer ID";

        }
    }
}
