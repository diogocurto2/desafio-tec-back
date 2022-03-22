using Model.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain.Interfaces
{
    public interface IUserService : IBaseService<User>
    {

        public User Authenticate(string login, string senha);

    }
}
