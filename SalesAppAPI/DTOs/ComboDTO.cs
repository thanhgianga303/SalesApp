using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SalesAppAPI.Models;

namespace SalesAppAPI.DTOs
{
    public class ComboDTO
    {
        public int ComboId { get; set; }
        public string ComboCode { get; set; }
        public string ComboName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalMoney { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
        public List<ComboDetails> ComboDetailsList { get; set; }
        public List<InvoiceDetails> InvoiceDetailsList { get; set; }
    }
}