using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain.Entities
{
    public class Card : BaseEntity
    {
        
        public string Titulo { get; set; }

        public string Conteudo { get; set; }

        public string Lista { get; set; }


    }
}
