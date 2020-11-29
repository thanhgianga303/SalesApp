using System.Linq;
using SalesAppAPI.Infrastructure;
using System.Threading.Tasks;
using SalesAppAPI.Models;
using SalesAppAPI.Models.IRepository;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SalesAppAPI.Data.Repository
{
    public class ComboRepository : Repository<Combo>, IComboRepository
    {
        private readonly SalesAppContext _context;
        public ComboRepository(SalesAppContext context) : base(context)
        {
            _context = context;
        }
        public async Task UpdateComboDetails(int comboId, List<ComboDetails> newListComboDetails)
        {
            var listComboDetails = _context.ComboDetails.Where(c => c.ComboId == comboId);
            _context.ComboDetails.RemoveRange(listComboDetails);
            await _context.ComboDetails.AddRangeAsync(newListComboDetails);
            await _context.SaveChangesAsync();
        }
    }
}