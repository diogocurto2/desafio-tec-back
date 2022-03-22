using Model.Domain.Entities;
using Model.Domain.Interfaces;
using Model.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Infra.Data.Repositories
{
    public class CardRepositoryEFMemory : ICardRepository
    {

        private readonly CardContext _context;

        public CardRepositoryEFMemory(CardContext cardContext)
        {
            _context = cardContext;
        }

        public void Delete(Guid id)
        {
            var card = _context.Cards.FirstOrDefault(x => x.Id == id);
            if(card != null)
            {
                _context.Cards.Remove(card);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException(String.Format("Card {0} não encontrado.", id));
            }
        }

        public Card Get(Guid id)
        {
            var card = _context.Cards.FirstOrDefault(x => x.Id == id);
            return card;
        }

        public IEnumerable<Card> GetAll()
        {
            var list = _context.Cards.ToList();

            return list;
        }

        public Card Insert(Card card)
        {
            card.Id = Guid.NewGuid();

            _context.Cards.Add(card);
            _context.SaveChanges(true);

            var cardUp = _context.Cards.FirstOrDefault(x => x.Id == card.Id);
            return cardUp;
        }

        public Card Update(Card card)
        {
            var cardToUp = _context.Cards.FirstOrDefault(x => x.Id == card.Id);
            if (cardToUp != null)
            {
                cardToUp.Lista = card.Lista;
                cardToUp.Titulo = card.Titulo;
                cardToUp.Conteudo = card.Conteudo;
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException(String.Format("Card {0} não encontrado.", card.Id));
            }

            var cardUp = _context.Cards.FirstOrDefault(x => x.Id == card.Id);
            return cardUp;
        }
    }
}
