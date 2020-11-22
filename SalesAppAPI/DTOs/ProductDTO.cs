using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SalesAppAPI.Models;

namespace SalesAppAPI.DTOs
{
    public class ProductDTO
    {
        public string ProductId { get; set; }
        public string CatalogId { get; set; }
        public string ProductName { get; set; }
        public string Details { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Catalog Catalog { get; set; }
        public List<Storage> StorageList { get; set; }
        public List<InvoiceDetails> InvoiceDetailsList { get; set; }
    }
}