using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ticaret.Entity;

namespace Ticaret.Models
{
    public class UserOrder
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState EnumOrderState { get; set; }
    }
}