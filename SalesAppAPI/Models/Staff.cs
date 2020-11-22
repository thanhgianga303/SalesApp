using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesAppAPI.Models
{
    public class Staff : People
    {
        [Key]
        [Required]
        public string StaffId { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}