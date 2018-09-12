using ATMDataAccess.Repositories;
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
                var TAccountdata = _AccountRepository.AccountDataInfoThroughAccountNumber(Ac.AccountNumber);
                if (depositAmount > 0)
                {
                    Ac.CurrentBalance += depositAmount;
                    TAccountdata.Balance += depositAmount;
                    _AccountRepository.SaveChanges();
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
                var TAccountdata = _AccountRepository.AccountDataInfoThroughAccountNumber(Ac.AccountNumber);
                if (withdrawamount > 0 && withdrawamount <= Ac.CurrentBalance)
                {
                    Ac.CurrentBalance -= withdrawamount;
                    TAccountdata.Balance -= withdrawamount;
                    _AccountRepository.SaveChanges();
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
                var TAccountdata = _AccountRepository.AccountDataInfoThroughAccountNumber(targetAccountNumber);
                if (TAccountdata != null)
                {
                    if (TAmount > 0 && TAmount <= Ac.CurrentBalance)
                    {
                        Ac.CurrentBalance -= TAmount;
                        TAccountdata.Balance -= TAmount;
                        _AccountRepository.SaveChanges();
                        return true;
                    }
                }
                
                return false;
            }
            catch (Exception e) { throw e; }
        }
    }
}