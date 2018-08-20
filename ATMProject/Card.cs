using ATMDataAccess;
using System.Configuration;


namespace ATMProject
{
    public class Card
    {

        private int _customerId { get; set; }
        private int _cardNumber { get; set; }
        private int _cardPin { get; set; }
        private string _cardStatus { get; set; }
        private bool _status { get; set; }
        private bool IsBlock = false;
        
        public Card(int cardNumber)
        {
            string connString = ConfigurationManager.ConnectionStrings["ATMConnectionString"].ToString();
            using (var db = new ATMDataModel())
            {
                foreach (var card in db.Cards)
                {
                    if (card.CardNumber == cardNumber)
                    {
                        this._status = true;
                        _customerId = card.CustomerId;
                        _cardNumber = cardNumber;
                        _cardStatus = card.CardStatus; ;
                        _cardPin = card.CardPin;
                        break;
                    }

                }
            }

        }
        public bool IsValid()
        {

            if (this._status == true &&
                    "Active".Equals(this._cardStatus, System.StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }
        public bool PinValidate(int PinNumber, out string ErrorMassage)
        {
            ErrorMassage = "";
            if (IsValid().Equals(true))
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
                            IsBlock = true;
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
        public string  BlockCard()
        {
            if (IsBlock == true)
            {
                this._cardStatus = "Blocked";
                return "Card Blocked";
            }
            return "Card NOT Blocked";
        }
        public string ChangePin(int OldPin, int NewPin) {

            if (IsValid()==true && this._cardPin==OldPin)
            {
                this._cardPin = NewPin;
                return "Card Pin Changed";
            }
            return "Card Pin is not Changed. Try again or Contact Customer Care Team";
        }
    }
}
