using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.EntitiesLayer.Enums;
using BlackJack.EntitiesLayer.Models;


namespace BlackJack.DataAccessLayer.Iterfaces
{
    interface ICardRepository
    {
        Task<IEnumerable<Card>> GetCards();
        Task<Card> GetCardById(int id);
        Task InsertCard(Card card);
        Task DeleteCard(int id);
        Task UpdateCard(Card card);
        Task Save();
    }
}
