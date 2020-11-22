using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
namespace SalesAppAPI.Models
{
    public class InvoiceDetails
    {
        [Key]
        [Required]
        public int InvoiceDetailsId { get; set; }
        public string InvoiceId { get; set; }
        public string ComboId { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public virtual Combo Combo { get; set; }
        public virtual Product Product { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}