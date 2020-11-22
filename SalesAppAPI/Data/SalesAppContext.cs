using Microsoft.EntityFrameworkCore;
using SalesAppAPI.Models;

namespace SalesAppAPI.Data
{
    public class SalesAppContext : DbContext
    {
        public SalesAppContext(DbContextOptions<SalesAppContext> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<ComboDetails> ComboDetails { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<DeliveryNote> DeliveryNotes { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}