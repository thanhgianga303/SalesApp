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
        public int InvoiceId { get; set; }
        public int? ComboId { get; set; }
        public int? ProductId { get; set; }
        public virtual Combo Combo { get; set; }
        public virtual Product Product { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}