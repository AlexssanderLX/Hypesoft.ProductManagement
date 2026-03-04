using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hypesoft.Domain.Entities;

namespace Hypesoft.Domain.Repositories
{
    public interface IProductRepository
    {

        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task<Product?> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> SearchByNameAsync(string name);
        Task<IEnumerable<Product>> GetAllAsync(int page, int pageSize);
        Task DeleteAsync(Guid id);
        Task<(IEnumerable<Product> Items, int TotalCount)>GetPagedAsync(int page, int pageSize);
    }
}
