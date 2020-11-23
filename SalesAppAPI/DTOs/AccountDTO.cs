using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SalesAppAPI.Models;

namespace SalesAppAPI.DTOs
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Staff Staff { get; set; }
        public Customer Customer { get; set; }
    }
}