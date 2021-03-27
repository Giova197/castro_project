using CastroProgetto.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastroProgetto.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync(IEnumerable<string> skus);

        Task<IEnumerable<Product>> GetProductsAsync(string category, int? priceLessThan);

        Task InserProductAsync(Product product);
    }
}
