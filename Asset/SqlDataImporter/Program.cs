using SqlDomain.Entities;
using SqlDomain.Services;
using SqlDomain.Services.Services;
using SqlDomain.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataImporter
{
    class Program
    {
        public static IUserService userService = new UserService();
        static void Main(string[] args)
        {

            using (var context = new DatabaseContext()) 
            {
                userService.Add(new User()
                {
                    Username = "Veljko",
                    Password = "test",
                    EntryDatetime = DateTime.Now,
                    LastUpdate = DateTime.Now,
                    IsDeleted = false
                });

            }
        }

        
    }
}
