using CastroProgetto.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastroProgetto.Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductOutput>> GetProductsAsync(string category, int? priceLessThan);
    }
}
