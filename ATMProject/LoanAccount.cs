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

        public override bool Depositfunds(int amount)
        {
            throw new NotImplementedException();
        }

        public override bool TransferFunds(int targetAccountNumber, int TAmount)
        {
            throw new NotImplementedException();
        }
    
        public override bool Withdrawfunds(int amount)
        {

            throw new NotImplementedException();
        }
    }
}
