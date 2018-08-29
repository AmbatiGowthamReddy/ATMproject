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

        public override void Depositfunds(int amount)
        {
            throw new NotImplementedException();
        }

        public override void TransferFunds(int targetAccountNumber, int TAmount)
        {
            throw new NotImplementedException();
        }
    
        public override void Withdrawfunds(int amount)
        {

            throw new NotImplementedException();
        }
    }
}
