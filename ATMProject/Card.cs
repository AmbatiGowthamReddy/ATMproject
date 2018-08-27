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

        public Card(int cardNumber, out string message)
        {
            message = PouplateData(cardNumber);
        }

        private string PouplateData(int cardNumber) {
            string connString = ConfigurationManager.ConnectionStrings["ATMConnectionString"].ToString();
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

                return "Card Is Not Valid";
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
        public bool PinValidate(int PinNumber, out string ErrorMassage)
        {
            ErrorMassage = "";
            if (IsCardValid().Equals(true))
            {

                var retryCount = 0;
                while (retryCount >= 0)
                {
                    if (PinNumber == this._cardPin)
                    {
                        ErrorMassage = "";
                        return true;
                    }
                    else
                    {

                        if (retryCount == 0)
                        {
                            BlockCard(_cardNumber);
                            ErrorMassage = ErrorMassage + "You have exceeded Max Number of trails. Your Card is blocked. Please contact the branch.";
                        }
                        else
                        {
                            retryCount--;
                            ErrorMassage = "Entered Wrong Pin Number. You have " + retryCount + " Chances.";
                        }
                        break;
                    }
                }


            }

            return false;
        }
        public string BlockCard(int cardNumber)
        {
            var card = dataModel.Cards.SingleOrDefault(p => p.CardNumber == cardNumber);
            if (card != null)
            {
                card.CardStatus = "Blocked";
                dataModel.SaveChanges();
                return "Card Blocked as per your request";
            }
            return "Card NOT Blocked";
        }
        public string ChangePin(int OldPin, int NewPin)
        {
            var card = dataModel.Cards.SingleOrDefault(p => p.CardNumber == this._cardNumber);
            if (IsCardValid() && this._cardPin == OldPin)
            {
                this._cardPin = NewPin;
                card.CardPin = NewPin;
                dataModel.SaveChanges();
                return "Card Pin Changed";
            }
            return "Card Pin is not Changed. Try again or Contact Customer Care Team";
        }
    }
}