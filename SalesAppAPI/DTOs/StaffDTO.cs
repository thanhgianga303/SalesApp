using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SalesAppAPI.Models;

namespace SalesAppAPI.DTOs
{
    public class Staff : People
    {
        public string StaffId { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}