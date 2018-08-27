using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(int cardNumber) : base(cardNumber)
        {

        }

        public override string Depositfunds(int depositAmount)
        {
            try
            {
                var accnbr = dataModel.Accounts.SingleOrDefault(p => p.AccountNumber == accountNumber);
                if (depositAmount > 0)
                {
                    accnbr.Balance += depositAmount;
                    dataModel.SaveChanges();
                    return $"{depositAmount} is added to your balance";
                }
                return "Enter Correct amount to deposit";
            }
            catch (Exception e)
            {
                return "Card Number don't have Account associated.";
                throw e;
            }
        }

        public override string Withdrawfunds(int withdrawamount)
        {
            try
            {
                var accnbr = dataModel.Accounts.SingleOrDefault(p => p.AccountNumber == accountNumber);
                if (withdrawamount > 0 && withdrawamount <= accnbr.Balance)
                {
                    accnbr.Balance -= withdrawamount;
                    dataModel.SaveChanges();
                    return $"{withdrawamount} is debited from your balance";
                }
                return "Enter Correct amount to withdraw";
            }
            catch (Exception e)
            {

                return "Card Number don't have Account associated.";
                throw e;
            }
        }
    }
}