using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointOfSales.Models
{
    public class Bill
    {
        public int ID { get; set; }
        public int TableNumber { get; set; }
        public int MenuID { get; set; }
        public virtual Menu Menu { get; set; }
        public int WorkProfileID { get; set; }
        public virtual WorkProfile WorkProfile { get; set; }
        public string UserID { get; set; }
    }
}