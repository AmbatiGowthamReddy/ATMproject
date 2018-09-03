using ATMProject;
using ATMProject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProjectUnitTesting
{
    [TestClass]
    public class CustomerTest
    {

        [TestCategory("Customer Method"), TestMethod]
        public void InValidCard_InvalidCustomerNameTest()
        {

            Customer c = new Customer();
            var data = c.GetCustomerDetails(1000);
            var actualCustomerName = data != null ? data.CustomerName : "";
            var ExpectedName = "";
            Assert.AreEqual(ExpectedName, actualCustomerName);
        }

        [TestCategory("Customer Method"), TestMethod]
        public void ValidCard_ValidCustomerNameTest()
        {

            Customer c = new Customer();
            var data = c.GetCustomerDetails(1);
            var actualCustomerName = data != null ? data.CustomerName : "";
            var ExpectedName = "Raj";
            Assert.AreEqual(ExpectedName,actualCustomerName);
        }

        [TestCategory("Customer Method"), TestMethod]
        public void ValidCard_ValidCustomerAddressTest()
        {

            Customer c = new Customer();
            var data = c.GetCustomerDetails(1);
            var actualCustomerAddress = data != null ? data.CustomerAddress : "";
            var ExpectedAddress = "Hyderabad";
            Assert.AreEqual(ExpectedAddress, actualCustomerAddress);
        }

        [TestCategory("Customer Method"), TestMethod]
        public void ValidCard_InvalidCustomerNameTest()
        {

            Customer c = new Customer();
            var data = c.GetCustomerDetails(18);
            var actualCustomerName = data != null ? data.CustomerName : "";
            Assert.AreEqual(null, actualCustomerName);
        }
        [TestCategory("Customer Method"), TestMethod]
        public void ValidCard_InvalidCustomerAdressTest()
        {

            Customer c = new Customer();
            var data = c.GetCustomerDetails(19);
            var actualCustomerAdress = data != null ? data.CustomerAddress : "";
            Assert.AreEqual(null, actualCustomerAdress);
        }
    }
}
