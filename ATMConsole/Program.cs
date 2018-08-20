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
           
            ATMProject.Card c = new ATMProject.Card(7);
            bool validCard = c.IsValid();
            string ScreenMessage;
            bool validatePin = c.PinValidate(222,out ScreenMessage);
            Console.WriteLine(ScreenMessage);
            string Pinchange = c.ChangePin(2222,1431);
            Console.WriteLine(validCard);
            Console.WriteLine(validatePin);

        }
    }
}
