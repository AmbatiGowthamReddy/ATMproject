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

        public override void Depositfunds(int depositAmount)
        {
            try
            {
                if (depositAmount > 0)
                {
                    Ac.CurrentBalance += depositAmount;
                    dataModel.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override void Withdrawfunds(int withdrawamount)
        {
            try
            {

                if (withdrawamount > 0 && withdrawamount <= Ac.CurrentBalance)
                {
                    Ac.CurrentBalance -= withdrawamount;
                    dataModel.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override void TransferFunds(int targetAccountNumber, int TAmount)
        {
            try
            {
                if (TAmount > 0 && TAmount <= Ac.CurrentBalance)
                {
                    Ac.CurrentBalance -= TAmount;
                    dataModel.SaveChanges();
                }

            }
            catch (Exception e) { throw e; }
        }
    }
}