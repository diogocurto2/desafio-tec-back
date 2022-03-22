using Model.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain.Interfaces
{
    public interface ICardRepository : IBaseRepository<Card>
    {
        public Card Get(Guid id);

        public Card Insert(Card card);

        public Card Update(Card card);

        public IEnumerable<Card> GetAll();

        public void Delete(Guid id);

    }
}
