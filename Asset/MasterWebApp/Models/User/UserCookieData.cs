using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterWebApp.Models.User
{
    public class UserCookieData
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime EntryDatetime { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}