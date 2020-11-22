using System.Linq;
using SalesAppAPI.Infrastructure;
using System.Threading.Tasks;
using SalesAppAPI.Models;
using SalesAppAPI.Models.IRepository;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SalesAppAPI.Data.Repository
{
    public class StorageRepository : Repository<Storage>, IStorageRepository
    {
        private readonly SalesAppContext _context;
        public StorageRepository(SalesAppContext context) : base(context)
        {
            _context = context;
        }
    }
}