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
            ATMProject.Account Ac = new ATMProject.SavingsAccount(12);
            string Message = Ac.Checkbalance();
            Console.WriteLine(Message);
            Console.Read();


        }
    }
}
