using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMDataAccess;
using System.Configuration;
using ATMProject;

namespace ATMConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            ATMProject.Customer c = new ATMProject.Customer();
            string CustomerDetails = c.ShowCustomerDetails(13);
            Console.WriteLine(CustomerDetails);
            


        }
    }
}
