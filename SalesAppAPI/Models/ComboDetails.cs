using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
namespace SalesAppAPI.Models
{
    public class ComboDetails
    {
        [Key]
        [Required]
        public int ComboDetailsId { get; set; }
        public string ComboId { get; set; }
        public string ProductId { get; set; }
        public virtual Combo Combo { get; set; }
        public virtual Product Product { get; set; }
    }
}