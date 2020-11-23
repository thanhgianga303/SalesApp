using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesAppAPI.Models
{
    public class Storage
    {
        [Key]
        [Required]
        public int StorageId { get; set; }
        public string StorageCode { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public DateTime ImportDate { get; set; }
        public DateTime ExportDate { get; set; }
        public virtual Product Product { get; set; }

    }
}