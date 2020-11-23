using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SalesAppAPI.Models;

namespace SalesAppAPI.DTOs
{
    public class CatalogDTO
    {
        public int CatalogId { get; set; }
        public string CatalogCode { get; set; }
        public string CatalogName { get; set; }
        public List<Product> ProductList { get; set; }
    }
}