using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesAppAPI.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int ProductId { get; set; }
        public int CatalogId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Details { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Catalog Catalog { get; set; }
        public virtual List<Storage> StorageList { get; set; }
        public virtual List<InvoiceDetails> InvoiceDetailsList { get; set; }
    }
}