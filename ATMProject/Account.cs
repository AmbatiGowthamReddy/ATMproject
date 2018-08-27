using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ATMDataAccess;


namespace ATMProject
{
    public abstract class Account
    {
        public int accountNumber;
        public string accountType;
        public string accountName;
        public double currentBalance;
        public int customerId;
        public ATMDataModel dataModel;


        public Account(int cardNumber)
        {
            PopulateAccountData(cardNumber);
        }


        public string PopulateAccountData(int cardNumber)
        {

            string connString = ConfigurationManager.ConnectionStrings["ATMConnectionString"].ToString();
            dataModel = new ATMDataModel();
            var cardData = dataModel.Cards.SingleOrDefault(p => p.CardNumber == cardNumber);
            try
            {
                if (cardData != null)
                {
                    this.customerId = cardData.CustomerId;
                    var accData = dataModel.Accounts.SingleOrDefault(p => p.CustomerId == customerId);
                    if (accData != null)
                    {
                        this.accountNumber = accData.AccountNumber;
                        this.accountName = accData.AccountName;
                        this.accountType = accData.AccountType;
                        this.customerId = accData.CustomerId;
                        this.currentBalance = accData.Balance;
                    }
                    else
                    {
                        return "Customer Id is invalid";
                    }
                }
                else
                {
                    return "card Number is Invalid";
                }
                return "Populated data without any issues";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string Checkbalance()
        {
            var accData = dataModel.Accounts.SingleOrDefault(p=>p.AccountNumber == this.accountNumber);
            if (accData != null)
            {
                return accData.Balance.ToString();
            }
            return "Account Number is Invalid";
        }


        public abstract string Depositfunds(int amount);


        public abstract string Withdrawfunds(int amount);
        public double TransferFunds(int targetAccountNumber)
        {
            return 0;
        }


    }
}