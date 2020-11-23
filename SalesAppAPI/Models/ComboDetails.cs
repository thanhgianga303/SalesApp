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
        public int ComboId { get; set; }
        public int ProductId { get; set; }
        public virtual Combo Combo { get; set; }
        public virtual Product Product { get; set; }
    }
}