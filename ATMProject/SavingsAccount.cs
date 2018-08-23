using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    class SavingsAccount : Account
    {
        public SavingsAccount(int accountNumber, string accountType, string accountName, double currentBalance, int customerId):base(accountNumber,accountType,accountName,currentBalance,customerId)
        {

        }
        public override void Depositfunds(int amount)
        {
            throw new NotImplementedException();
        }

        public override int Withdrawfunds(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
