using Model.Domain.Entities;
using Model.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Service.Services
{
    public class CardService : ICardService
    {

        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public void Delete(Guid id)
        {
            var card = _cardRepository.Get(id);

            if (card != null)
            {
                _cardRepository.Delete(id);
            }
            else
            {
                throw new Exception(String.Format("Card id {0} não encontrado.", id));
            }
        }

        public IEnumerable<Card> GetAll()
        {
            return _cardRepository.GetAll();
        }

        public Card Insert(Card card)
        {
            return _cardRepository.Insert(card);
        }

        public Card Update(Guid id, Card card)
        {
            var cardP = _cardRepository.Get(id);

            if (cardP != null)
            {
                card.Id = cardP.Id;
                return _cardRepository.Update(card);
            }
            else
            {
                throw new Exception(String.Format("Card id {0} não encontrado.", card.Id));
            }
        }
    }
}
