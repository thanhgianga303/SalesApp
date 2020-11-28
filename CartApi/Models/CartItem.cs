using System;

namespace CartApi.Models
{
    public class CartItem
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Price { get; set; }
        public string CatalogName { get; set; }
        public string ProductForm { get; set; }
        public string ImageUrl { get; set; }
    }
}