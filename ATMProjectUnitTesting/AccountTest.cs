using ATMProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProjectUnitTesting
{
    [TestClass]
   public class AccountTest
    {
        [TestCategory("Account Class Info Property"), TestMethod]
        public void Info_AccountName_Test()
        {
            Account acc = new SavingsAccount(1);
            var AccountName = acc.Info.AccountName;
            Assert.AreEqual(AccountName, "SaralSavings");
        }

        [TestCategory("Account Class Info Property"), TestMethod]
        public void Info_AccountNumber_Test()
        {
            Account acc = new SavingsAccount(1);
            var AccountNumber = acc.Info.AccountNumber;
            Assert.AreEqual(AccountNumber, 1);
        }

        [TestCategory("Account Class Info Property"), TestMethod]
        public void Info_AccountType_Test()
        {
            Account acc = new SavingsAccount(1);
            var AccountType = acc.Info.AccountType;
            Assert.AreEqual(AccountType, "Savings");
        }

        [TestCategory("Account Class Info Property"), TestMethod]
        public void Info_AccountBalance_Test()
        {
            Account acc = new SavingsAccount(1);
            var CurrentBalance = acc.Info.CurrentBalance;
            Assert.AreEqual(CurrentBalance, 100);
        }

        [TestCategory("Account Class Info Property"), TestMethod]
        public void Info_CustomerId_Test()
        {
            Account acc = new SavingsAccount(1);
            var CustomerId = acc.Info.CustomerId;
            Assert.AreEqual(CustomerId, 1);
        }

        [TestCategory("Account Class CheckBalance Method"), TestMethod]
        public void CheckBalance_Test()
        {
            Account acc = new SavingsAccount(1);
            var Balance = acc.Checkbalance();
            Assert.AreEqual(Balance, 100);
        }

    }
}
