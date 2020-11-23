using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesAppAPI.Models
{
    public class Catalog
    {
        [Key]
        [Required]
        public int CatalogId { get; set; }
        public string CatalogCode { get; set; }
        public string CatalogName { get; set; }
        public virtual List<Product> ProductList { get; set; }
    }
}