using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SalesAppAPI.Models;

namespace SalesAppAPI.DTOs
{
    public class RoleDTO
    {
        public int RoleId { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public List<Staff> StaffList { get; set; }
        public List<Customer> CustomerList { get; set; }
    }
}