using SqlDomain.Entities;
using SqlDomain.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDomain.Services.Services
{
    public class UserService : IUserService
    {

        public void Add(User user)
        {
            using (var context = new DatabaseContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public User GetByUsername(string username)
        {
            User result = null;
            using (var context = new DatabaseContext())
            {
                result = context.Users.FirstOrDefault(x => x.Username == username);
            }

            return result;
        }

        public bool IsValidUser(string username, string password)
        {
            bool result = false;
            using (var context = new DatabaseContext())
            {
                result = context.Users.FirstOrDefault(x => x.Username == username && x.Password == password) != null;
            }

            return result;
        }
    }
}
