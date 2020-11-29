using System.Collections.Generic;
using System.Threading.Tasks;
using SalesAppAPI.Infrastructure;
using SalesAppAPI.Models;

namespace SalesAppAPI.Models.IRepository
{
    public interface IComboRepository : IRepository<Combo>
    {
        Task UpdateComboDetails(int comboId, List<ComboDetails> newListComboDetails);
    }
}