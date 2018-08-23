using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public abstract class Account
    {
        private int accountNumber;
        private string accountType;
        private string accountName;
        private double currentBalance;
        private int customerId;

        public Account(int accountNumber, string accountType, string accountName, double currentBalance, int customerId )
        {
            this.accountNumber = accountNumber;
            this.accountType = accountType;
            this.accountName = accountName;
            this.currentBalance = currentBalance;
            this.customerId = customerId;
        }

        public double Checkbalance()
        {
            return 0;
        }
        public abstract void Depositfunds(int amount);
        public abstract int Withdrawfunds(int amount);
        public double Transfer(int targetAccountNumber)
        {
            return 0;
        }


    }
}