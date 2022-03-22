using Model.Domain.Entities;
using Model.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Infra.Data.Repositories
{
    public class UserRepositoryMemory : IUserRepository
    {
        public User Get(string login, string senha)
        {
            var users = new List<User>();
            users.Add(new User { Id = Guid.NewGuid(), login = "letscode", senha = "lets@123" });
            return users.Where(x => x.login.ToLower() == login.ToLower() && x.senha == x.senha).FirstOrDefault();
        }
    }
}
