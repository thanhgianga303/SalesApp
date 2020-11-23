using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SalesAppAPI.Models;

namespace SalesAppAPI.DTOs
{
    public class StaffDTO : People
    {
        public int StaffId { get; set; }
        public int AccountId { get; set; }
        public string StaffCode { get; set; }
        public Account Account { get; set; }
    }
}