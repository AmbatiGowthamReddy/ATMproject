using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATMProject;

namespace ATMProjectUnitTesting
{
    [TestClass]
    public class CardTest
    {
        [TestCategory("CardValid Method"), TestMethod]
        public void ExistingCardNumber_CardValidationTest()
        {

            Card c = new Card(1);
            var ValidCard = c.IsCardValid();
            Assert.AreEqual(true, ValidCard);
        }
        [TestCategory("CardValid Method"), TestMethod]
        public void NonExistingCardNumber_CardValidationTest()
        {

            Card c = new Card(505);
            var ValidCard = c.IsCardValid();
            Assert.AreEqual(false, ValidCard);
        }
        [TestCategory("CardValid Method"), TestMethod]
        public void Active_ExistingCardNumber_CardValidationTest()
        {

            Card c = new Card(11);
            var ValidCard = c.IsCardValid();
            Assert.AreEqual(true, ValidCard);
        }
        [TestCategory("CardValid Method"), TestMethod]
        public void NonActive_ExistingCardNumber_CardVadlidaiton()
        {

            Card c = new Card(9);
            var ValidCard = c.IsCardValid();
            Assert.AreEqual(false, ValidCard);
        }
        [TestCategory("PinValid Method"), TestMethod]
        public void validCard_validPin_Pinvalidate()
        {
            Card c = new Card(1);
            var validpin = c.PinValidate(1111);
            Assert.AreEqual(true, validpin);
        }
        [TestCategory("PinValid Method"), TestMethod]
        public void ValidCard_InvalidPin_Pinvalidate()
        {
            Card c = new Card(1);
            var invalidpin = c.PinValidate(2222222);
            Assert.AreEqual(false, invalidpin);
        }
        [TestCategory("PinValid Method"), TestMethod]
        public void InValidCard_InvalidPin_Pinvalidate()
        {
            Card c = new Card(101010101);
            var invalidpin = c.PinValidate(2222222);
            Assert.AreEqual(false, invalidpin);
        }
        [TestCategory("Block Method"), TestMethod]
        public void InValidCard_BlockCard()
        {
            Card c = new Card(101010101);
            var cardstatus = c.BlockCard();
            Assert.AreEqual(false, cardstatus);
        }
        [TestCategory("Block Method"), TestMethod]
        public void ValidCard_BlockCard()
        {
            Card c = new Card(7);
            var cardstatus = c.BlockCard();
            Assert.AreEqual(true, cardstatus);
        }
        [TestCategory("ChangePin Method"), TestMethod]
        public void ChangePin_ValidCard_SameOldPinAsNewPin()
        {
            Card c = new Card(7);
            var PinchangedStatus = c.ChangePin(2222, 2222);
            Assert.AreEqual(false, PinchangedStatus);
        }
        [TestCategory("ChangePin Method"), TestMethod]
        public void ChangePin_ValidCard_validOldPin()
        {
            Card c = new Card(15);
            var PinchangedStatus = c.ChangePin(0, 1515);
            Assert.AreEqual(true, PinchangedStatus);
        }
        [TestCategory("ChangePin Method"), TestMethod]
        public void ChangePin_InValidCard_InvalidOldPin()
        {
            Card c = new Card(2);
            var PinchangedStatus = c.ChangePin(7777, 1234);
            Assert.AreEqual(false, PinchangedStatus);
        }
        [TestCategory("ChangePin Method"), TestMethod]
        public void ChangePin_ValidCard_InvalidOldPin()
        {
            Card c = new Card(7);
            var PinchangedStatus = c.ChangePin(7777, 1234);
            Assert.AreEqual(false, PinchangedStatus);
        }
    }
}
