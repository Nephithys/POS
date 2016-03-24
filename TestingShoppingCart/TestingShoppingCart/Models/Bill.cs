using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingShoppingCart.Models
{
    public class Bill
    {
        public int ID { get; set; }
        public int TableNumber { get; set; }
        public int ItemID { get; set; }
        public virtual Item Item { get; set; }
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
    }
}