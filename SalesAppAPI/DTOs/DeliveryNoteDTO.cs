using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SalesAppAPI.Models;

namespace SalesAppAPI.DTOs
{
    public class DeliveryNoteDTO
    {
        public string DeliveryNoteId { get; set; }
        public string InvoiceId { get; set; }
        public string StaffId { get; set; }
        public string Address { get; set; }
        public DateTime ShipDate { get; set; }
        public decimal ShipCost { get; set; }
        public string PhoneNumber { get; set; }
        public Invoice Invoice { get; set; }
        public Staff Staff { get; set; }

    }
}