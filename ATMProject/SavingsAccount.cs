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

        public override bool Depositfunds(int depositAmount)
        {
            
            try
            {
                    var accnbr = dataModel.Accounts.SingleOrDefault(p => p.AccountNumber == Ac.AccountNumber);
                    if (depositAmount > 0)
                {
                    Ac.CurrentBalance += depositAmount;
                    accnbr.Balance += depositAmount;
                    dataModel.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override bool Withdrawfunds(int withdrawamount)
        {
            try
            {
                var accnbr = dataModel.Accounts.SingleOrDefault(p => p.AccountNumber == Ac.AccountNumber);
                if (withdrawamount > 0 && withdrawamount <= Ac.CurrentBalance)
                {
                    Ac.CurrentBalance -= withdrawamount;
                    accnbr.Balance -= withdrawamount;
                    dataModel.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override bool TransferFunds(int targetAccountNumber, int TAmount)
        {
            try
            {
                var TAccountdata = dataModel.Accounts.SingleOrDefault(p=>p.AccountNumber==targetAccountNumber);
                if (TAccountdata != null)
                {
                    if (TAmount > 0 && TAmount <= Ac.CurrentBalance)
                    {
                        Ac.CurrentBalance -= TAmount;
                        TAccountdata.Balance -= TAmount;
                        dataModel.SaveChanges();
                        return true;
                    }
                }
                
                return false;
            }
            catch (Exception e) { throw e; }
        }
    }
}