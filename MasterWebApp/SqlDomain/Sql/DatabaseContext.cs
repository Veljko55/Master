using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using SqlDomain.Entities;

namespace SqlDomain.Sql
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(ConfigurationManager.ConnectionStrings["Sql"].ConnectionString) 
        {
            Database.Log = s => Debug.WriteLine(s);
        }

        public DbSet<User> Users { get; set; }

    }
}
