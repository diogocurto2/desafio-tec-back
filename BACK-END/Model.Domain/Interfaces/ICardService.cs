using Model.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain.Interfaces
{
    public interface ICardService : IBaseService<Card>
    {

        public Card Insert(Card card);

        public Card Update(Guid id, Card card);  

        public IEnumerable<Card> GetAll();  

        public void Delete(Guid id); 

    }
}
