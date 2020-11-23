using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesAppAPI.Models
{
    public class People
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdentityCard { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}