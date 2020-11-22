using System;
using System.Threading.Tasks;
using SalesAppAPI.Models.IRepository;

namespace SalesAppAPI.Models.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        IComboRepository Combos { get; }
        ICatalogRepository Catalogs { get; }
        ICustomerRepository Customers { get; }
        IDeliveryNoteRepository DeliveryNotes { get; }
        IInvoiceRepository Invoices { get; }
        IProductRepository Products { get; }
        IRoleRepository Roles { get; }
        IStaffRepository Staff { get; }
        IStorageRepository Storage { get; }
        Task<int> Complete();
    }
}