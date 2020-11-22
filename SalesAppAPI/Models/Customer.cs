using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesAppAPI.Models
{
    public class Customer : People
    {
        [Key]
        [Required]
        public string CustomerId { get; set; }
        public bool isNew { get; set; }
        public int? AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}