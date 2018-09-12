using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ATMDataAccess;
using ATMProject.Models;
using ATMDataAccess.Repositories;

namespace ATMProject
{
    public abstract class Account
    {
        protected AccountInfo Ac;
        protected IAccountRepository _AccountRepository;
        protected ICardRepository _cardRepository;
        
       

        public Account(int cardNumber)
        {
            _AccountRepository = new AccountRepository();
            _cardRepository = new CardRepository();
            PopulateAccountData(cardNumber);
        }
        public void PopulateAccountData(int cardNumber)
        {
            try
            {
                Ac = new AccountInfo();
                var cardData = _cardRepository.ReadCardInfo(cardNumber);
                if (cardData != null)
                {
                    Ac.CustomerId = cardData.CustomerId;
                    var accData = _AccountRepository.ReadAccountInfoThroughCustomerID(Ac.CustomerId);
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