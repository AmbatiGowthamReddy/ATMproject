using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ATMDataAccess;
using ATMProject.Models;

namespace ATMProject
{
    public abstract class Account
    {
        protected AccountInfo Ac;
        protected ATMDataModel dataModel;
       

        public Account(int cardNumber)
        {
            dataModel = new ATMDataModel();
            PopulateAccountData(cardNumber);
        }
        public void PopulateAccountData(int cardNumber)
        {

            try
            {
                Ac = new AccountInfo();
                var cardData = dataModel.Cards.SingleOrDefault(p => p.CardNumber == cardNumber);
                if (cardData != null)
                {
                    Ac.CustomerId = cardData.CustomerId;
                      var  accData = dataModel.Accounts.SingleOrDefault(p => p.CustomerId == Ac.CustomerId);
                    if (accData != null)
                    {
                        Ac.AccountNumber = accData.AccountNumber;
                        Ac.AccountName = accData.AccountName;
                        Ac.AccountType = accData.AccountType;
                        Ac.CustomerId = accData.CustomerId;
                        Ac.CurrentBalance = accData.Balance;
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public AccountInfo Info
        {
            get { return Ac; }
        }
        public double Checkbalance()
        {
            return Ac.CurrentBalance;
        }
        public abstract bool Depositfunds(int amount);
        public abstract bool Withdrawfunds(int amount);
        public abstract bool TransferFunds(int targetAccountNumber, int amount);
    }
}