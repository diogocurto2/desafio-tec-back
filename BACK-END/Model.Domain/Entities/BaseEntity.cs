using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }


        public override bool Equals(object? obj)
        {
            return Id.Equals(((BaseEntity)obj).Id);
        }
    }
}
