using System.Collections.Generic;
using System.Threading.Tasks;
using SalesAppAPI.Infrastructure;
using SalesAppAPI.Models;

namespace SalesAppAPI.Models.IRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
}