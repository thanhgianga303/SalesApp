using System.Linq;
using SalesAppAPI.Infrastructure;
using System.Threading.Tasks;
using SalesAppAPI.Models;
using SalesAppAPI.Models.IRepository;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SalesAppAPI.Data.Repository
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        private readonly SalesAppContext _context;
        public InvoiceRepository(SalesAppContext context) : base(context)
        {
            _context = context;
        }
        public async Task<InvoiceDetails> GetByInvoiceDetails(int id)
        {
            var invoiceDetails = await _context.InvoiceDetails.FindAsync(id);
            return invoiceDetails;
        }
        public async Task AddInvoiceDetails(InvoiceDetails invoiceDetails)
        {
            await _context.InvoiceDetails.AddAsync(invoiceDetails);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateInvoiceDetails(InvoiceDetails invoiceDetails)
        {
            _context.InvoiceDetails.Update(invoiceDetails);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteInvoiceDetails(int id)
        {
            var invoiceDetails = await _context.InvoiceDetails.FindAsync(id);
            _context.InvoiceDetails.Remove(invoiceDetails);
            await _context.SaveChangesAsync();
        }
    }
}