using Model.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User Get(string login, string senha);
    }
}
