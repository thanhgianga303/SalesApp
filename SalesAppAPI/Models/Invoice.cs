using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesAppAPI.Models
{
    public class Invoice
    {
        [Key]
        [Required]
        public string InvoiceId { get; set; }
        public string CustomerID { get; set; }
        public string StaffID { get; set; }
        public string InvoiceName { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal TotalMoney { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual DeliveryNote DeliveryNote { get; set; }
        public virtual List<InvoiceDetails> InvoiceDetailsList { get; set; }

    }
}