using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;


namespace SCADA.ScadaDB
{
    public class ScadaContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Entities.ScadaBreaker> Breakers { get; set; }

        public ScadaContext()
        {

            Database.SetCommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);

        }
        public ScadaContext(DbContextOptions<ScadaContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Scada;Integrated Security=True;MultipleActiveResultSets=true;");
        }
    }
}
