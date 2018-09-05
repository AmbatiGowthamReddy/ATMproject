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
                if (depositAmount > 0)
                {
                    Ac.CurrentBalance += depositAmount;
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

                if (withdrawamount > 0 && withdrawamount <= Ac.CurrentBalance)
                {
                    Ac.CurrentBalance -= withdrawamount;
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
                var TAccountNumber = dataModel.Accounts.SingleOrDefault(p=>p.AccountNumber==targetAccountNumber);
                if (TAccountNumber!=null)
                {
                    if (TAmount > 0 && TAmount <= Ac.CurrentBalance)
                    {
                        Ac.CurrentBalance -= TAmount;
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