using SqlDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDomain.Services
{
    public interface IUserService
    {
        void Add(User user);
        User GetByUsername(string username);
        bool IsValidUser(string username, string password);
    }
}
