using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMDataAccess.Repositories
{
    public interface IAccountRepository
    {
        void CreateAccount(Account A);
        Account ReadAccountInfoThroughCustomerID(int CustomerId);
        void UpdateAccountData(Account A);
        Account AccountDataInfoThroughAccountNumber(int AccountNumber);
        void SaveChanges();
    }
}
