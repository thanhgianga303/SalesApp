using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesAppAPI.Models
{
    public class Account
    {
        [Key]
        [Required]
        public string AccountId { get; set; }
        public string RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual Role Role { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Customer Customer { get; set; }

    }
}