using SqlDomain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDomain.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
