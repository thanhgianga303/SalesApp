using System.Collections.Generic;

namespace SalesAppAPI.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string CatalogId { get; set; }
        public string ProductName { get; set; }
        public Catalog Catalog;
        public List<ProductDetails> ProductDetailsList { get; set; }
    }
}