using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMDataAccess;
using System.Configuration;
using ATMProject;
using ATMProject.Models;

namespace ATMConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            ATMProject.Customer Ac = new ATMProject.Customer();
            CustomerInfo Message = Ac.GetCustomerDetails(25);

            Console.WriteLine("Customer Info: {0}{1}{2}", Message.CustomerId.ToString(), Message.CustomerName, Message.CustomerAddress);

            Console.Read();


        }
    }
}
