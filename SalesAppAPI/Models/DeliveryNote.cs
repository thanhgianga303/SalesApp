using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesAppAPI.Models
{
    public class DeliveryNote
    {
        [Key]
        [Required]
        public string DeliveryNoteId { get; set; }
        public string InvoiceId { get; set; }
        public string StaffId { get; set; }
        public string Address { get; set; }
        public DateTime ShipDate { get; set; }
        public decimal ShipCost { get; set; }
        public string PhoneNumber { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Staff Staff { get; set; }

    }
}