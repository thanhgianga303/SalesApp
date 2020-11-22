using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SalesAppAPI.Models;

namespace SalesAppAPI.DTOs
{
    public class CustomerDTO : People
    {
        public string CustomerId { get; set; }
        public bool isNew { get; set; }
        public int? AccountId { get; set; }
        public Account Account { get; set; }
    }
}