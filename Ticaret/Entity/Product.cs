using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticaret.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string image { get; set; }
        public double price { get; set; }
        public int Stock { get; set; }
        public bool IsFeatured { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}