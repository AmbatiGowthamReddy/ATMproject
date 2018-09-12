using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMDataAccess.Repositories
{
    public interface ICardRepository
    {
        void CreateCard(Card C);
        Card ReadCardInfo(int Id);
        void UpdateCardData(Card C);
        void SaveChanges();
    }
}
