using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SalesAppAPI.Models;

namespace SalesAppAPI.DTOs
{
    public class DeliveryNoteDTO
    {
        public int DeliveryNoteId { get; set; }
        public int InvoiceId { get; set; }
        public int StaffId { get; set; }
        public string DeliveryNoteCode { get; set; }
        public string Address { get; set; }
        public DateTime ShipDate { get; set; }
        public decimal ShipCost { get; set; }
        public string PhoneNumber { get; set; }
        public Invoice Invoice { get; set; }
        public Staff Staff { get; set; }

    }
}