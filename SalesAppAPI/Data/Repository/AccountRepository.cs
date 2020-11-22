using System.Linq;
using SalesAppAPI.Infrastructure;
using System.Threading.Tasks;
using SalesAppAPI.Models;
using SalesAppAPI.Models.IRepository;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SalesAppAPI.Data.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly SalesAppContext _context;
        public AccountRepository(SalesAppContext context) : base(context)
        {
            _context = context;
        }
    }
}