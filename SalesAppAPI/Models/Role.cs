using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesAppAPI.Models
{
    public class Role
    {
        [Key]
        [Required]
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public virtual List<Staff> StaffList { get; set; }
        public virtual List<Customer> CustomerList { get; set; }
    }
}