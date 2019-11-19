using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyApp.Models
{
    public class MyAppContext : DbContext
    {
     
    
        public MyAppContext() : base("name=MyAppContext")
        {
        }

        public DbSet<Clients> Clients { get; set; }

        public DbSet<ClientAddress> ClientAddresses { get; set; }
    }
}
