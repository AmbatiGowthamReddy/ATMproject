using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMDataAccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private ATMDataModel dataModel;
        public AccountRepository()
        {
            dataModel = new ATMDataModel();
        }
        public void CreateAccount(Account A)
        {
            throw new NotImplementedException();
        }

        public Account AccountDataInfoThroughAccountNumber(int AccountNumber)
        {
            return dataModel.Accounts.SingleOrDefault(p => p.AccountNumber == AccountNumber);
        }

        public Account ReadAccountInfoThroughCustomerID(int CustomerId)
        {
            return dataModel.Accounts.SingleOrDefault(p=>p.CustomerId== CustomerId);
        }

        public void SaveChanges()
        {
            dataModel.SaveChanges();
        }

        public void UpdateAccountData(Account A)
        {
            throw new NotImplementedException();
        }

    }
}
