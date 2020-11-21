using System;
using System.Collections.Generic;

namespace SalesAppAPI.Models
{
    public class Combo
    {
        public string ComboId { get; set; }
        public string ComboName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Price { get; set; }
        public List<Product> ProductList { get; set; }
    }
}