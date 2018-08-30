using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATMProject;

namespace ATMProjectUnitTesting
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void ExistingCardNumber_CardValidationTest()
        {

            Card c = new Card(1);
            var ValidCard = c.IsCardValid();
            Assert.AreEqual(true, ValidCard);
        }
        [TestMethod]
        public void NonExistingCardNumber_CardValidationTest()
        {

            Card c = new Card(505);
            var ValidCard = c.IsCardValid();
            Assert.AreEqual(false, ValidCard);
        }
        [TestMethod]
        public void Active_ExistingCardNumber_CardValidationTest()
        {

            Card c = new Card(11);
            var ValidCard = c.IsCardValid();
            Assert.AreEqual(true, ValidCard);
        }

        [TestMethod]
        public void NonActive_ExistingCardNumber_CardVadlidaiton()
        {

            Card c = new Card(9);
            var ValidCard = c.IsCardValid();
            Assert.AreEqual(false, ValidCard);
        }

        [TestMethod]
        public void validCard_validPin_Pinvalidate()
        {
            Card c = new Card(1);
            var validpin = c.PinValidate(1111);
            Assert.AreEqual(true, validpin);
        }

        [TestMethod]
        public void ValidCard_InvalidPin_Pinvalidate()
        {
            Card c = new Card(1);
            var invalidpin = c.PinValidate(2222222);
            Assert.AreEqual(false, invalidpin);
        }

        [TestMethod]
        public void InValidCard_InvalidPin_Pinvalidate()
        {
            Card c = new Card(101010101);
            var invalidpin = c.PinValidate(2222222);
            Assert.AreEqual(false, invalidpin);
        }

        [TestMethod]
        public void InValidCard_BlockCard()
        {
            Card c = new Card(101010101);
            var cardstatus = c.BlockCard();
            Assert.AreEqual(false, cardstatus);
        }
        [TestMethod]
        public void ValidCard_BlockCard()
        {
            Card c = new Card(7);
            var cardstatus = c.BlockCard();
            Assert.AreEqual(true, cardstatus);
        }

        [TestMethod]
        public void ChangePin_ValidCard_validOldPin()
        {
            Card c = new Card(7);
            var PinchangedStatus = c.ChangePin(2222,1234);
            Assert.AreEqual(true, PinchangedStatus);
        }

        [TestMethod]
        public void ChangePin_InValidCard_InvalidOldPin()
        {
            Card c = new Card(2);
            var PinchangedStatus = c.ChangePin(7777, 1234);
            Assert.AreEqual(false, PinchangedStatus);
        }

        [TestMethod]
        public void ChangePin_ValidCard_InvalidOldPin()
        {
            Card c = new Card(7);
            var PinchangedStatus = c.ChangePin(7777, 1234);
            Assert.AreEqual(false, PinchangedStatus);
        }
    }
}
