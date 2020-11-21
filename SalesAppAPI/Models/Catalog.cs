using System.Collections.Generic;

namespace SalesAppAPI.Models
{
    public class Catalog
    {
        public string CatalogId { get; set; }
        public string CatalogName { get; set; }
        public List<Product> ProductList { get; set; }
    }
}