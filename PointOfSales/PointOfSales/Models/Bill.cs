using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PointOfSales.Models
{
    public class Bill
    {
        public int ID { get; set; }
        [Display(Name = "Table Number")]
        public int TableNumber { get; set; }

        [Display(Name = "Menu")]
        public int MenuID { get; set; }
        public virtual Menu Menu { get; set; }

        [Display(Name = "Server")]
        public int WorkProfileID { get; set; }
        public virtual WorkProfile WorkProfile { get; set; }

        public string UserID { get; set; }
    }
}