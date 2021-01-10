using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

using System.Data.Entity;
using System.Diagnostics;

namespace AssetSCADA.ScadaDB
{
    public class ScadaContext : DbContext
    {
        public DbSet<Entities.ScadaBreaker> Breakers { get; set; }

        public ScadaContext() : base(ConfigurationManager.ConnectionStrings["Scada"].ConnectionString)
        {
            Database.Log = s => Debug.WriteLine(s);
            //discuss this how long should be set
            this.Database.CommandTimeout = 180;
        }
    }
}
