using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using SalesAppAPI.Models;

namespace SalesAppAPI.DTOs
{
    public class ComboDetailsDTO
    {
        public int ComboDetailsId { get; set; }
        public string ComboId { get; set; }
        public string ProductId { get; set; }
        public Combo Combo { get; set; }
        public Product Product { get; set; }
    }
}