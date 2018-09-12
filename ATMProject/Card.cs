using ATMDataAccess;
using ATMDataAccess.Repositories;
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

        ICardRepository _cardRepository;
        //private ATMDataModel dataModel;

        public Card(int cardNumber)
        {
            _cardRepository = new CardRepository();
            PouplateData(cardNumber);
        }

        private void PouplateData(int cardNumber)
        {
          
            //dataModel = new ATMDataModel();
            //var card = dataModel.Cards.SingleOrDefault(p => p.CardNumber == cardNumber);
            var card = _cardRepository.ReadCardInfo(cardNumber);
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
            if (IsCardValid())
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
            if (IsCardValid())
            {
                var card = _cardRepository.ReadCardInfo(_cardNumber);
                card.CardStatus = "Blocked";
               _cardRepository.SaveChanges();
                return true;
            }
            return false;
        }
        public bool ChangePin(int OldPin, int NewPin)
        {
            if (OldPin!=NewPin)
            {
                if (IsCardValid() && this._cardPin == OldPin)
                {
                    var card = _cardRepository.ReadCardInfo(_cardNumber);
                    this._cardPin = NewPin;
                    card.CardPin = NewPin;
                    _cardRepository.SaveChanges();
                    return true;
                }
            }
            
            return false;
        }
    }
}