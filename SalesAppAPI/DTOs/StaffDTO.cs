using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SalesAppAPI.Models;

namespace SalesAppAPI.DTOs
{
    public class StaffDTO : People
    {
        public string StaffId { get; set; }
        public string AccountId { get; set; }
        public Account Account { get; set; }
    }
}