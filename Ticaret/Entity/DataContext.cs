using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticaret.Entity
{
    public class DataContext: DbContext
    {
        public DataContext():base("dataConnection")
        {
            Database.SetInitializer(new DataInitilaizer());
        }
        public DbSet<Product> Products  { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }
}