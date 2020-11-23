using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SalesAppAPI.Models;

namespace SalesAppAPI.DTOs
{
    public class StorageDTO
    {
        public int StorageId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public string StorageCode { get; set; }
        public DateTime ImportDate { get; set; }
        public DateTime ExportDate { get; set; }
        public Product Product { get; set; }
    }
}