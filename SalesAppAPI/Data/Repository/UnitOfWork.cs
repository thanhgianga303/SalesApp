
using System.Threading.Tasks;
using SalesAppAPI.Models.IRepository;

namespace SalesAppAPI.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SalesAppContext _context;
        public IAccountRepository Accounts { get; private set; }
        public IComboRepository Combos { get; private set; }
        public ICatalogRepository Catalogs { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public IDeliveryNoteRepository DeliveryNotes { get; private set; }
        public IInvoiceRepository Invoices { get; private set; }
        public IProductRepository Products { get; private set; }
        public IRoleRepository Roles { get; private set; }
        public IStaffRepository Staff { get; private set; }
        public IStorageRepository Storage { get; private set; }
        public UnitOfWork(SalesAppContext context)
        {
            _context = context;
            Accounts = new AccountRepository(context);
            Combos = new ComboRepository(context);
            Catalogs = new CatalogRepository(context);
            DeliveryNotes = new DeliveryNoteRepository(context);
            Customers = new CustomerRepository(context);
            Invoices = new InvoiceRepository(context);
            Products = new ProductRepository(context);
            Staff = new StaffRepository(context);
            Roles = new RoleRepository(context);
            Storage = new StorageRepository(context);

        }
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}