﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PointOfSales.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        [Display(Name = "Special of the Day")]
        public bool isSpecial { get; set; }
        public string MenuImage { get; set; }
    }
}