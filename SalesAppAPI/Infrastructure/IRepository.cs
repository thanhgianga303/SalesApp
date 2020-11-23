using System.Collections.Generic;
using System.Threading.Tasks;
namespace SalesAppAPI.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetBy(string id);
        Task Add(T entity);
        Task Update(string id, T entity);
        Task Delete(string id);
    }
}