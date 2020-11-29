using System.Collections.Generic;
using System.Threading.Tasks;
using SalesAppAPI.Infrastructure;
using SalesAppAPI.Models;

namespace SalesAppAPI.Models.IRepository
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        Task<InvoiceDetails> GetByInvoiceDetails(int id);
        Task AddInvoiceDetails(InvoiceDetails invoiceDetails);
        Task UpdateInvoiceDetails(InvoiceDetails invoiceDetails);
        Task DeleteInvoiceDetails(int id);
    }
}