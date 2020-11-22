using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesAppAPI.Models
{
    public class Combo
    {
        [Key]
        [Required]
        public string ComboId { get; set; }
        public string ComboName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalMoney { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
        public virtual List<ComboDetails> ComboDetailsList { get; set; }
        public virtual List<InvoiceDetails> InvoiceDetailsList { get; set; }
    }
}