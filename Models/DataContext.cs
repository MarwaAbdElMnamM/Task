using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Task.Models
{
    public class DataContext:DbContext
    {
        public DataContext() : base("name=Task")
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientPhoneNumber> clientPhoneNumbers { get; set; }
    }
}