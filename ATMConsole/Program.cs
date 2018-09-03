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
            ATMProject.Account Ac = new ATMProject.SavingsAccount(12);
            double Balance= Ac.Checkbalance();
            Console.WriteLine(Balance);
            Console.Read();

        }
    }
}
