using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATMProject;

namespace ATMProjectUnitTesting
{
    [TestClass]
    public class SavingsAccountsTest
    {
        [TestCategory("DepositFunds"), TestMethod]
        public void DepositFunds_ifAmountGreaterthanzero()
        {
            Account acc = new SavingsAccount(7);
            var BalanceBeforeDeposit = acc.Checkbalance();
            acc.Depositfunds(200);
            var BalanceAfterDeposit = acc.Checkbalance();
            Assert.AreEqual((BalanceBeforeDeposit + 200), BalanceAfterDeposit);

        }
        [TestCategory("DepositFunds"), TestMethod]
        public void DepositFunds_ifAmountLessthanzero()
        {
            Account acc = new SavingsAccount(7);
            var pervBal = acc.Checkbalance();
            var Depositstatus = acc.Depositfunds(-200);
            Assert.AreEqual(false, Depositstatus);
        }
        [TestCategory("DepositFunds"), TestMethod]
        public void DepositFunds_ifAmountequaltozero()
        {
            Account acc = new SavingsAccount(7);
            var pervBal = acc.Checkbalance();
            var Depositstatus = acc.Depositfunds(0);
            Assert.AreEqual(false, Depositstatus);
        }
        [TestCategory("WithDrawfunds"), TestMethod]
        public void WithDrawfunds_ifamountislessthanZero()
        {
            Account acc = new SavingsAccount(7);
            var Withdrawstatus = acc.Withdrawfunds(-200);
            Assert.AreEqual(false, Withdrawstatus);
        }

        [TestCategory("WithDrawfunds"), TestMethod]
        public void WithDrawfunds_ifamountisGreaterthanCurBal()
        {
            Account acc = new SavingsAccount(7);
            var withdrawstatus = acc.Withdrawfunds(1000000000);
            Assert.AreEqual(false, withdrawstatus);
        }

        [TestCategory("WithDrawfunds"), TestMethod]
        public void WithDrawfunds_ifamountisLessZerEqualsToCurBal()
        {
            Account acc = new SavingsAccount(7);
            var CurBal = Convert.ToInt32(acc.Checkbalance());
            var withdrawstatus = acc.Withdrawfunds(CurBal);
            Assert.AreEqual(true, withdrawstatus);
        }

        [TestCategory("Transferfunds"), TestMethod]
        public void Transferfunds_ifIncorrectAccountNumber()
        {
            Account acc = new SavingsAccount(7);
            //var CurBal = Convert.ToInt32(acc.Checkbalance());
            var CurBal = acc.Checkbalance();
            var accstatus = acc.TransferFunds(100, 200);
            //var withdrawstatus = acc.Withdrawfunds(CurBal);
            Assert.AreEqual(false, accstatus);
        }

        [TestCategory("Transferfunds"), TestMethod]
        public void Transferfunds_correctAccountNumberandAmountGreaterThanCurrentBalance()
        {
            Account acc = new SavingsAccount(7);
            //var CurBal = Convert.ToInt32(acc.Checkbalance());
            var CurBal = acc.Checkbalance();
            var accstatus = acc.TransferFunds(2, 200);
            //var withdrawstatus = acc.Withdrawfunds(CurBal);
            Assert.AreEqual(false, accstatus);
        }
        [TestCategory("Transferfunds"), TestMethod]
        public void Transferfunds_correctAccountNumberandAmountLessThanCurrentBalance()
        {
            Account acc = new SavingsAccount(7);
            var CurBal = acc.Checkbalance();
            var accstatus = acc.TransferFunds(2, 100);
            Assert.AreEqual(true, accstatus);
        }
        [TestCategory("Transferfunds"), TestMethod]
        public void Transferfunds_correctAccountNumberandAmountLessThanZero()
        {
            Account acc = new SavingsAccount(7);
            //var CurBal = Convert.ToInt32(acc.Checkbalance());
            var CurBal = acc.Checkbalance();
            var accstatus = acc.TransferFunds(2, -200);
            //var withdrawstatus = acc.Withdrawfunds(CurBal);
            Assert.AreEqual(false, accstatus);
        }
        [TestCategory("Transferfunds"), TestMethod]
        public void Transferfunds_correctAccountNumberandAmountGreaterThanCurrentBal()
        {
            Account acc = new SavingsAccount(7);
            //var CurBal = Convert.ToInt32(acc.Checkbalance());
            var CurBal = acc.Checkbalance() + 200;
            var accstatus = acc.TransferFunds(2, Convert.ToInt32(CurBal));
            //var withdrawstatus = acc.Withdrawfunds(CurBal);
            Assert.AreEqual(false, accstatus);
        }
    }
}