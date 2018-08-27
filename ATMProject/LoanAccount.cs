using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public class LoanAccount : Account
    {
        public LoanAccount(int cardNumber):base(cardNumber)
        {

        }

        public override string Depositfunds(int amount)
        {
            if (accountType=="Loan")
            {
                Account A = new SavingsAccount(customerId);
                return A.Depositfunds(amount);
            }
            else
            {
                return "You don't have Loan Account";
            }
        }

        public override string Withdrawfunds(int amount)
        {
            
            if (accountType == "Loan")
            {
                Account A = new SavingsAccount(customerId);
                return A.Withdrawfunds(amount);

            }
            else
            {
                return "You don't have Loan Account";
            }
        }
       
    }
}
