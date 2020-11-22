using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using SalesAppAPI.Models;

namespace SalesAppAPI.DTOs
{
    public class InvoiceDetailsDTO
    {
        public int InvoiceDetailsId { get; set; }
        public string InvoiceId { get; set; }
        public string ComboId { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public Combo Combo { get; set; }
        public Product Product { get; set; }
        public Invoice Invoice { get; set; }
    }
}