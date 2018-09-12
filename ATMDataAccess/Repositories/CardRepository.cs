using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMDataAccess.Repositories
{
    public class CardRepository : ICardRepository
    {
        private ATMDataModel dataModel;
        public CardRepository()
        {
            dataModel = new ATMDataModel();
        }
        public void CreateCard(Card C)
        {
            throw new NotImplementedException();
        }

        public Card ReadCardInfo(int Id)
        {
           return dataModel.Cards.SingleOrDefault(p => p.CardNumber == Id);
        }

        public void SaveChanges()
        {
            dataModel.SaveChanges();
        }

        public void UpdateCardData(Card C)
        {
            throw new NotImplementedException();
        }
    }
}
