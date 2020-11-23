using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SalesAppAPI.Models;

namespace SalesAppAPI.DTOs
{
    public class InvoiceDTO
    {
        public int InvoiceId { get; set; }
        public int CustomerID { get; set; }
        public int StaffID { get; set; }
        public string InvoiceCode { get; set; }
        public string InvoiceName { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal TotalMoney { get; set; }
        public Staff Staff { get; set; }
        public Customer Customer { get; set; }
        public DeliveryNote DeliveryNote { get; set; }
        public List<InvoiceDetails> InvoiceDetailsList { get; set; }

    }
}