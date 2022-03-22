using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain.Entities
{
    public class User : BaseEntity
    {

        public string login { get; set; }
        public string senha { get; set; }

    }
}
