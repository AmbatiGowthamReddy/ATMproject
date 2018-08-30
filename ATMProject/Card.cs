using ATMDataAccess;
using System;
using System.Configuration;
using System.Linq;


namespace ATMProject
{
    public class Card
    {

        private int _customerId { get; set; }
        private int _cardNumber { get; set; }
        private int _cardPin { get; set; }
        private string _cardStatus { get; set; }
        private string _status { get; set; }

       
        private ATMDataModel dataModel;

        public Card(int cardNumber)
        {
         
            PouplateData(cardNumber);
        }

        private void PouplateData(int cardNumber)
        {
          
            dataModel = new ATMDataModel();
            var card = dataModel.Cards.SingleOrDefault(p => p.CardNumber == cardNumber);
            try
            {
                if (card != null)
                {
                    this._status = "True";
                    _customerId = card.CustomerId;
                    _cardNumber = cardNumber;
                    _cardStatus = card.CardStatus;
                    _cardPin = card.CardPin;
                }
            }
            catch (Exception e)
            {
                this._status = e.ToString();
                throw e;
            }
        }
        public bool IsCardValid()
        {

            if (this._status == "True" &&
                    "Active".Equals(this._cardStatus, System.StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }
        public bool PinValidate(int PinNumber)
        {
            if (IsCardValid().Equals(true))
            {
                if (PinNumber == this._cardPin)
                {
                    return true;
                }
            }

            return false;
        }
        public bool BlockCard()
        {
            if (IsCardValid().Equals(true))
            {
                var card = dataModel.Cards.SingleOrDefault(p => p.CardNumber == this._cardNumber);
                card.CardStatus = "Blocked";
                dataModel.SaveChanges();
                return true;
            }
            return false;
        }
        public bool ChangePin(int OldPin, int NewPin)
        {
            if (IsCardValid() && this._cardPin == OldPin)
            {
                var card = dataModel.Cards.SingleOrDefault(p => p.CardNumber == this._cardNumber);
                this._cardPin = NewPin;
                card.CardPin = NewPin;
                dataModel.SaveChanges();
                return true;
            }
            return false;
        }
    }
}